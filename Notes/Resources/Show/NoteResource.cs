namespace Notes.API.Notes.Resources.Show;

public class NoteResource
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Text { get; set; }
    public DateTime? Date { get; set; }
}