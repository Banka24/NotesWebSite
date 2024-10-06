namespace MyNotes.Contracts
{
	public record class NoteDto(Guid Id, string Title, string Description, DateTime CreateAt);
}