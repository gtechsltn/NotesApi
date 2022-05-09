
namespace NotesApi.Repository
{
    public interface INotesRepository
    {
        Task<Notes> CreateNotesasync(Notes notes);

        Task<IEnumerable<Notes>> GetAllNotesAsync(string userId);

        Task DeleteNotesAsync(string notesId);
    }
}