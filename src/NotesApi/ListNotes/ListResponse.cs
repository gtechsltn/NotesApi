using NotesApi.Repository;

namespace NotesApi.ListNotes
{
    public class ListResponse
    {
        public IEnumerable<Notes> notes { get; set; } = Enumerable.Empty<Notes>();
    }
}
