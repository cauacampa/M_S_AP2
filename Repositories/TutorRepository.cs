using Microsoft.EntityFrameworkCore;

public class TutorRepository : ITutorRepository
{
    private readonly AppDbContext _context;

    public TutorRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Tutor>> GetAllAsync()
    {
        return await _context.Tutores.ToListAsync();
    }

    public async Task<Tutor?> GetByIdAsync(int id)
    {
        return await _context.Tutores.FindAsync(id);
    }

    public async Task<Tutor> AddTutorAsync(Tutor tutor)
    {
        _context.Tutores.Add(tutor);
        await _context.SaveChangesAsync();
        return tutor;
    }

    public async Task UpdateAsync(Tutor tutorAtualizado)
    {
        _context.Tutores.Update(tutorAtualizado);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var tutor = await GetByIdAsync(id);
        if (tutor != null)
        {
            _context.Tutores.Remove(tutor);
            await _context.SaveChangesAsync();
        }
    }
}
