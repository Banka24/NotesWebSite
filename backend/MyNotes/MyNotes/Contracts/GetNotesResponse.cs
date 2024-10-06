namespace MyNotes.Contracts
{
	public record class GetNotesResponse(IList<NoteDto> Notes);
}