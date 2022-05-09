namespace NotesApi.DeleteNotes
{
    public class DeleteRequest
    {
        public string NotesId { get; set; } = string.Empty;

        public string UserId { get; set; } = string.Empty;
    }
}
