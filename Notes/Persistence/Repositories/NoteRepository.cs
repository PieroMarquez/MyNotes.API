using Microsoft.EntityFrameworkCore;
using Notes.API.Notes.Domain.Models;
using Notes.API.Notes.Domain.Repositories;
using Notes.API.Shared.Persistence.Context;
using Notes.API.Shared.Persistence.Repositories;

namespace Notes.API.Notes.Persistence.Repositories;

public class NoteRepository : BaseRepository, INoteRepository
{
    public NoteRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }

    public async Task<IEnumerable<Note?>> FindAllAsync()
    {
        var notes = await AppDbContext.Notes.ToListAsync();
        return notes.AsEnumerable();
    }

    public async Task<Note?> FindAsync(int id)
    {
        return await AppDbContext.Notes.FindAsync(id);
    }

    public async Task AddAsync(Note note)
    {
        await AppDbContext.Notes.AddAsync(note);
    }
}