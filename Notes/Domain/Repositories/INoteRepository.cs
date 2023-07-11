using Notes.API.Notes.Domain.Models;

namespace Notes.API.Notes.Domain.Repositories;

public interface INoteRepository
{
    Task<IEnumerable<Note?>> FindAllAsync();

    Task<Note?> FindAsync(int id);

    Task AddAsync(Note note);
}