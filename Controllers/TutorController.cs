using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]

public class TutorController : ControllerBase
{
    private readonly ITutorRepository _repo;

    public TutorController(ITutorRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Tutor>>> Get() =>
        Ok(await _repo.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<Tutor>> GetById(int id)
    {
        var tutor = await _repo.GetByIdAsync(id);
        return tutor is null ? NotFound() : Ok(tutor);
    }

    [HttpPost]
    public async Task<ActionResult<Tutor>> Post(Tutor tutor)
    {
        return Ok(await _repo.AddTutorAsync(tutor));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Tutor tutor)
    {
        var tutorExistente = await _repo.GetByIdAsync(id);
        if (tutorExistente is null) return NotFound();

        tutor.Id = id;
        await _repo.UpdateAsync(tutor);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var tutor = await _repo.GetByIdAsync(id);
        if (tutor is null) return NotFound();

        await _repo.DeleteAsync(id);
        return NoContent();
    }
}