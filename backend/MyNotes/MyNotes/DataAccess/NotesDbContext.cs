using Microsoft.EntityFrameworkCore;
using MyNotes.Models;

namespace MyNotes.DataAccess
{
	public class NotesDbContext(IConfiguration configuration) : DbContext
	{
		private readonly IConfiguration _configuration = configuration;

		public DbSet<Note> Notes => Set<Note>();

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql(_configuration.GetConnectionString("Database"));
		}
	}
}