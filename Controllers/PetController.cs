using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]

public class PetController : ControllerBase
{

    private readonly IPetRepository _repo;
    private readonly ITutorRepository _tutorRepository;

    public PetController(IPetRepository repo, ITutorRepository tutorRepository)
    {
        _repo = repo;
        _tutorRepository = tutorRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pet>>> Get() =>
        Ok(await _repo.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<Pet>> GetById(int id)
    {
        var pet = await _repo.GetByIdAsync(id);
        return pet is null ? NotFound() : Ok(pet);
    }

    [HttpPost]

    public async Task<ActionResult<Pet>> Post(Pet pet)
    {
        var tutor = await _tutorRepository.GetByIdAsync(pet.TutorId);
        if (tutor == null)
            return NotFound();

        return Ok(await _repo.AddPetAsync(pet));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Pet pet)
    {
        var petExistente = await _repo.GetByIdAsync(id);
        if (petExistente is null) return NotFound();

        pet.Id = id;
        await _repo.UpdateAsync(pet);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var pet = await _repo.GetByIdAsync(id);
        if (pet is null) return NotFound();

        await _repo.DeleteAsync(id);
        return NoContent();
    }
}