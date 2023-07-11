using Notes.API.Notes.Domain.Models;
using Notes.API.Notes.Domain.Repositories;
using Notes.API.Notes.Domain.Services;
using Notes.API.Notes.Domain.Services.Communication;
using Notes.API.Shared.Domain.Repositories;

namespace Notes.API.Notes.Services;

public class NoteService : INoteService
{
    private readonly INoteRepository _noteRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public NoteService(INoteRepository noteRepository, IUnitOfWork unitOfWork)
    {
        _noteRepository = noteRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<Note?>> FindAllAsync()
    {
        return await _noteRepository.FindAllAsync();
    }

    public async Task<NoteResponse> FindAsync(int id)
    {
        var existingNote = await _noteRepository.FindAsync(id);
        if (existingNote == null)
            return new NoteResponse("Note does not exist!");
        return new NoteResponse(existingNote);
    }

    public async Task<NoteResponse> AddAsync(Note note)
    {
        try
        {
            await _noteRepository.AddAsync(note);
            await _unitOfWork.CompleteAsync();
            return new NoteResponse(note);
        }
        catch (Exception e)
        {
            return new NoteResponse(e.Message);
        }
    }
}