using Google.Cloud.Firestore;

namespace NotesApi.Repository
{
    [FirestoreData]
    public class Notes
    {
        [FirestoreDocumentId]
        public string NotesId { get; set; } = string.Empty;

        [FirestoreProperty]
        public string UserId { get; set; } = string.Empty;

        [FirestoreProperty]
        public string Content { get; set; } = string.Empty;

        [FirestoreProperty]
        public string AttachmentUrl { get; set; } = string.Empty;

        [FirestoreDocumentCreateTimestamp]
        public DateTime CreatedDateTime { get; set; }
    }
}
