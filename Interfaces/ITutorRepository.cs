public interface ITutorRepository
{
    Task<IEnumerable<Tutor>> GetAllAsync();
    Task<Tutor?> GetByIdAsync(int id);
    Task<Tutor> AddTutorAsync(Tutor tutor);
    Task UpdateAsync(Tutor tutorAtualizado);
    Task DeleteAsync(int id);
}
