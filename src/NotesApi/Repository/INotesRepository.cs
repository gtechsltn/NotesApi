namespace NotesApi.Repository
{
    public interface INotesRepository
    {
        Task<Notes> CreateNotesAsync(Notes notes);

        Task<IEnumerable<Notes>> GetAllNotesAsync(string userId);

        Task DeleteNotesAsync(string notesId);

        Task<Notes> UpdateNotesAsync(Notes notes);

        Task<Notes?> GetNotes(string notesId);
    }
}