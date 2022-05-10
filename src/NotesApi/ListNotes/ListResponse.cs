using NotesApi.Repository;

namespace NotesApi.ListNotes
{
    public class ListResponse
    {
        public IEnumerable<Notes> Notes { get; set; } = Enumerable.Empty<Notes>();
    }
}
