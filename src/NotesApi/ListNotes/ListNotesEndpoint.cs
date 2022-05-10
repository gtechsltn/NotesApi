using NotesApi.Repository;

namespace NotesApi.ListNotes
{
    public class ListNotesEndpoint : Endpoint<ListNotesRequest, ListResponse>
    {
        private readonly INotesRepository notesRepository;

        public ListNotesEndpoint(INotesRepository notesRepository)
        {
            this.notesRepository = notesRepository;
        }

        public override void Configure()
        {
            Verbs(Http.GET);
            Routes("/api/notes/{UserId}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(ListNotesRequest req, CancellationToken ct)
        {
            var notes = await this.notesRepository.GetAllNotesAsync(req.UserId);
            await SendOkAsync(new ListResponse { notes = notes });
        }
    }
}
