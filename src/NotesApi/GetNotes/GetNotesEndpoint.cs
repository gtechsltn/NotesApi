using NotesApi.Repository;

namespace NotesApi.GetNotes
{
    public class GetNotesEndpoint : Endpoint<GetNotesRequest, GetNotesResponse>
    {
        private readonly INotesRepository notesRepository;

        public GetNotesEndpoint(INotesRepository notesRepository)
        {
            this.notesRepository = notesRepository;
        }

        public override void Configure()
        {
            Verbs(Http.GET);
            Routes("/api/notes/{UserId}/{NoteId}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(GetNotesRequest req, CancellationToken ct)
        {
            var note = await this.notesRepository.GetNotes(req.NotesId);
            if (note == null)
            {
                await SendNotFoundAsync(ct);
            }

            await SendOkAsync(new GetNotesResponse
            {
                Notes = note,
            });
        }
    }
}
