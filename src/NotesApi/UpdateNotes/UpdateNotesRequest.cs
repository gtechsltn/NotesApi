namespace NotesApi.UpdateNotes
{
    public class UpdateNotesRequest
    {
        public string NotesId { get; set; } = string.Empty;

        public string UserId { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public string AttachementUrl { get; set; } = string.Empty;
    }
}
