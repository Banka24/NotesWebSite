using System.ComponentModel.DataAnnotations;

namespace MyNotes.Models
{
	public class Note(string title, string description)
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		[Required, MaxLength(255)]
		public string Title { get; set; } = title;
		public string Description { get; set; } = description;
		public DateTime CreateAt { get; set; } = DateTime.UtcNow;
	}
}