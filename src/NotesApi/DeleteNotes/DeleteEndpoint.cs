using NotesApi.Repository;

namespace NotesApi.DeleteNotes
{
    public class DeleteEndpoint : Endpoint<DeleteRequest>
    {
        private readonly INotesRepository notesRepository;

        public DeleteEndpoint(INotesRepository notesRepository)
        {
            this.notesRepository = notesRepository;
        }


        public override void Configure()
        {
            Verbs(Http.DELETE);
            Routes("api/notes/{UserId}/{NotesId}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(DeleteRequest req, CancellationToken ct)
        {
            await this.notesRepository.DeleteNotesAsync(req.NotesId);
            await SendNoContentAsync();
        }
    }
}
