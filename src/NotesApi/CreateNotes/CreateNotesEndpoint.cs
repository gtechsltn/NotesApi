using NotesApi.Repository;

namespace NotesApi.CreateNotes
{
    public class CreateNotesEndpoint : EndpointWithMapping<CreateNotes, CreateNotestResponse, Notes>
    {
        private readonly INotesRepository notesRepository;

        public CreateNotesEndpoint(INotesRepository notesRepository)
        {
            this.notesRepository = notesRepository;
        }

        public override void Configure()
        {
            Verbs(Http.POST);
            Routes("/api/notes");
            AllowAnonymous();
        }

        public override async Task<CreateNotestResponse> ExecuteAsync(CreateNotes req, CancellationToken ct)
        {
            Notes notes = MapToEntity(req);
            var savedNotes = await this.notesRepository.CreateNotesasync(notes);
            return MapFromEntity(savedNotes);
        }

        public override Notes MapToEntity(CreateNotes r) => new Notes
        {
            UserId = r.UserId,
            Content = r.Content,
            AttachmentUrl = r.Attachment
        };

        public override CreateNotestResponse MapFromEntity(Notes e) => new CreateNotestResponse
        {
            NotesId = e.NotesId,
            CreatedDateTime = e.CreatedDateTime,
        };

    }
}
