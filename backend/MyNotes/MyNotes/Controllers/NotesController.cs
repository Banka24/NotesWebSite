using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyNotes.Contracts;
using MyNotes.DataAccess;
using MyNotes.Models;
using System.Linq.Expressions;

namespace MyNotes.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class NotesController(NotesDbContext context) : Controller
	{
		private readonly NotesDbContext _context = context;

		[HttpPost]
		public async Task<IActionResult> CreateNote([FromBody] CreateNoteReaquest reaquest, CancellationToken token)
		{
			var note = new Note(reaquest.Title, reaquest.Description);
			await _context.Notes.AddAsync(note, token);
			await _context.SaveChangesAsync(token);
			return Ok();
		}

		[HttpGet]
		public async Task<IActionResult> Get([FromQuery] GetNotesRequest request, CancellationToken token)
		{
			var notesQuery = _context.Notes
				.Where(n => string.IsNullOrWhiteSpace(request.Search) ||
				n.Title.ToLower().Contains(request.Search.ToLower()));

			Expression<Func<Note, object>> selectorKey = request.SortItem?.ToLower() switch
			{
				"date" => note => note.CreateAt,
				"title" => note => note.Title,
				_ => note => note.Id
			};

			notesQuery = request.SortOrder?.ToLower() == "desc" ? notesQuery.OrderByDescending(selectorKey) : notesQuery.OrderBy(selectorKey);

			var noteDtos = await notesQuery
				.Select(n => new NoteDto(n.Id, n.Title, n.Description, n.CreateAt))
				.ToListAsync(token);

			return Ok(new GetNotesResponse(noteDtos));
		}
	}
}