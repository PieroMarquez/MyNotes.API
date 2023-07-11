using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Notes.API.Notes.Domain.Models;
using Notes.API.Notes.Domain.Services;
using Notes.API.Notes.Resources.Create;
using Notes.API.Notes.Resources.Show;
using Swashbuckle.AspNetCore.Annotations;

namespace Notes.API.Notes.Interface.Rest.Controllers;
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("CRUD for Notes 💨")]
public class NoteController : ControllerBase
{

    private readonly INoteService _noteService;
    private readonly IMapper _mapper;
    
    public NoteController(INoteService noteService, IMapper mapper)
    {
        _noteService = noteService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<NoteResource>> GetAll()
    {
        return _mapper.Map<IEnumerable<Note>, IEnumerable<NoteResource>>(await _noteService.FindAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetNoteById(int id)
    {
        var result = await _noteService.FindAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);
        var mappedResource = _mapper.Map<Note, NoteResource>(result.Resource!);
        return Ok(mappedResource);
    }

    [HttpPost]
    public async Task<IActionResult> CreateNewNote([FromBody, SwaggerRequestBody("New Note")] CreateNoteResource createNoteResource)
    {
        var mappedResource = _mapper.Map<CreateNoteResource, Note>(createNoteResource);
        var result = await _noteService.AddAsync(mappedResource);

        if (!result.Success)
            return BadRequest(result.Message);
        var mappedResultResource = _mapper.Map<Note, NoteResource>(result.Resource!);
        return Ok(mappedResultResource);
    }
}