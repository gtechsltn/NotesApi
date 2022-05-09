namespace NotesApi.CreateNotes
{
    public class CreateNotesEndpoint : Endpoint<CreateNotes, CreateNotestResponse>
    {
        public override void Configure()
        {
            Verbs(Http.POST);
            Routes("/api/notes");
            AllowAnonymous();
        }

        public override async Task<CreateNotestResponse> ExecuteAsync(CreateNotes req, CancellationToken ct)
        {
            var response = new CreateNotestResponse
            {
                NotesId = Guid.NewGuid().ToString(),
                CreatedDateTime = DateTime.Now
            };
            return await Task.FromResult(response);
        }
    }
}
