public interface IPetService
{
    Task<Pet> GetPetByIdAsync(int id);
    Task<IEnumerable<Pet>> GetAllPetsAsync();
    Task<IEnumerable<Pet>> GetPetsByTutorIdAsync(int tutorId);
    Task<Pet> AddPetAsync(Pet pet);
    Task<Pet> UpdatePetAsync(Pet pet);
    Task<bool> DeletePetAsync(int id);
}