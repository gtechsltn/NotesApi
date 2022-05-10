using Google.Cloud.Firestore;

namespace NotesApi.Repository
{
    public class NotesRepository : INotesRepository
    {
        private readonly FirestoreDb db;
        private readonly CollectionReference collection;

        public NotesRepository(FirestoreDb firestoreDb)
        {
            this.db = firestoreDb;
            this.collection = db.Collection("notes");
        }

        public async Task<Notes> CreateNotesAsync(Notes notes)
        {
            DocumentReference reference = await collection.AddAsync(notes);
            notes.NotesId = reference.Id;
            notes.CreatedDateTime = DateTime.UtcNow;
            return notes;
        }

        public async Task DeleteNotesAsync(string notesId)
        {
            DocumentReference document = db.Document($"notes/{notesId}");
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

        public async Task<Notes?> GetNotes(string notesId)
        {
            DocumentReference document = db.Document($"notes/{notesId}");
            DocumentSnapshot documentSnapshot = await document.GetSnapshotAsync();
            Notes notes = documentSnapshot.ConvertTo<Notes>();
            return notes;
        }

        public async Task<Notes> UpdateNotesAsync(Notes notes)
        {
            DocumentReference documentReference = db.Document($"notes/{notes.NotesId}");
            await documentReference.SetAsync(notes, SetOptions.MergeAll);
            return notes;
        }
    }
}
