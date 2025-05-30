public interface IPetRepository
{
    Task<IEnumerable<Pet>> GetAllAsync();
    Task<Pet?> GetByIdAsync(int id);
    Task<Pet> AddPetAsync(Pet pet);
    Task UpdateAsync(Pet petAtualizado);
    Task DeleteAsync(int id);
}