namespace NotesPresistence;

public class Note
{
    public string? UserId { get; set; }
    public string? Id { get; set; }
    public string? Title { get; set; }
    public string? Details { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? EditDate { get; set; }
}