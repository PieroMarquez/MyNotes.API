using AutoMapper;
using Notes.API.Notes.Domain.Models;
using Notes.API.Notes.Resources.Create;

namespace Notes.API.Notes.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<CreateNoteResource, Note>();
    }
}