using NotesApi.Repository;

namespace NotesApi.UpdateNotes
{
    public class UpdateNotesEndpoint : EndpointWithMapping<UpdateNotesRequest,EmptyResponse,Notes>
    {
        private readonly INotesRepository notesRepository;

        public UpdateNotesEndpoint(INotesRepository notesRepository)
        {
            this.notesRepository = notesRepository;
        }

        public override void Configure()
        {
            Verbs(Http.PUT);
            Routes("/api/notes");
            AllowAnonymous();
        }

        public override async Task HandleAsync(UpdateNotesRequest req, CancellationToken ct)
        {
            Notes notes = MapToEntity(req);
            await this.notesRepository.UpdateNotesAsync(notes);
            await SendOkAsync();
        }

        public override Notes MapToEntity(UpdateNotesRequest r) => new Notes
        {
            UserId = r.UserId,
            NotesId = r.NotesId,
            AttachmentUrl = r.AttachementUrl,
            Content = r.Content,
        };
        
    }
}
