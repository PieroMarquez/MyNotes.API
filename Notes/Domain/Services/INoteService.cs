using Notes.API.Notes.Domain.Models;
using Notes.API.Notes.Domain.Services.Communication;

namespace Notes.API.Notes.Domain.Services;

public interface INoteService
{
    Task<IEnumerable<Note?>> FindAllAsync();
    Task<NoteResponse> FindAsync(int id);
    Task<NoteResponse> AddAsync(Note note);
}