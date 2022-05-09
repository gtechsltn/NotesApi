using Google.Cloud.Firestore;

namespace NotesApi.Repository
{
    public class NotesRepository : INotesRepository
    {
        private readonly FirestoreDb Db;
        private readonly CollectionReference collection;

        public NotesRepository(FirestoreDb firestoreDb)
        {
            this.Db = firestoreDb;
            this.collection = Db.Collection("notes");
        }

        public async Task<Notes> CreateNotesasync(Notes notes)
        {
            DocumentReference reference = await collection.AddAsync(notes);
            notes.NotesId = reference.Id;
            notes.CreatedDateTime = DateTime.UtcNow;
            return notes;
        }

        public async Task DeleteNotesAsync(string notesId)
        {
            DocumentReference document = Db.Document($"notes/{notesId}");
            await document.DeleteAsync();
        }

        public async Task<IEnumerable<Notes>> GetAllNotesAsync(string userId)
        {
            List<Notes> notes = new List<Notes>();
            var query = collection.WhereEqualTo("UserId", userId);
            QuerySnapshot documentSnapshots = await query.GetSnapshotAsync();
            foreach (var item in documentSnapshots.Documents)
            {
                notes.Add(item.ConvertTo<Notes>());
            }
            return notes;
        }
    }
}
