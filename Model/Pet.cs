using System.ComponentModel.DataAnnotations;
public class Pet
{
    public int Id { get; set; }
    [Required]
    public string Nome { get; set; }
    [Required]
    public string Especie { get; set; }
    public string? Raca { get; set; }
    public int TutorId { get; set; }
    public Tutor? Tutor { get; set; }
}