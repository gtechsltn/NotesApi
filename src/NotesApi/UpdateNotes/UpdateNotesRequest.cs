namespace NotesApi.UpdateNotes
{
    public class UpdateNotesRequest
    {
        public string NotesId { get; set; }

        public string UserId { get; set; }

        public string Content { get; set; }

        public string AttachementUrl { get; set; }
    }
}
