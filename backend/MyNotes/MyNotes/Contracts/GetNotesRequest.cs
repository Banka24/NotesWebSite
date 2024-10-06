namespace MyNotes.Contracts
{
	public record class GetNotesRequest(string? Search, string? SortItem, string? SortOrder);
}