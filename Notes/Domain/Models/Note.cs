namespace Notes.API.Notes.Domain.Models;

public class Note
{
    public int Id { get; set; }
    
    public string? Title { get; set; }
    
    public string? Description { get; set; }
    
    public string? Text { get; set; }
    
    public DateTime? Date { get; set; }
}