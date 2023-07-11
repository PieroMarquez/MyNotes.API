using Notes.API.Notes.Domain.Models;
using Notes.API.Shared.Services.Communication;

namespace Notes.API.Notes.Domain.Services.Communication;

public class NoteResponse :BaseResponse<Note>
{
    public NoteResponse(Note resource) : base(resource)
    {
    }

    public NoteResponse(string message) : base(message)
    {
    }
}