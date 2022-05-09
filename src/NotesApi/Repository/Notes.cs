using Google.Cloud.Firestore;

namespace NotesApi.Repository
{
    [FirestoreData]
    public class Notes
    {
        [FirestoreDocumentId]
        public string NotesId { get; set; }

        [FirestoreProperty]
        public string UserId { get; set; }

        [FirestoreProperty]
        public string Content { get; set; }

        [FirestoreProperty]
        public string AttachmentUrl { get; set; }

        [FirestoreDocumentCreateTimestamp]
        public DateTime CreatedDateTime { get; set; }
    }
}
