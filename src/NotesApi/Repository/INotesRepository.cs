
namespace NotesApi.Repository
{
    public interface INotesRepository
    {
        Task<Notes> CreateNotesasync(Notes notes);
    }
}