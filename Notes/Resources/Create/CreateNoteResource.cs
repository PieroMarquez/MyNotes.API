namespace Notes.API.Notes.Resources.Create;

public class CreateNoteResource
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Text { get; set; }
    public DateTime? Date { get; set; }
}