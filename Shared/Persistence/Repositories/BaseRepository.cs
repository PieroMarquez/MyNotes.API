using Notes.API.Shared.Persistence.Context;

namespace Notes.API.Shared.Persistence.Repositories;

public class BaseRepository
{
    protected AppDbContext AppDbContext { get; set; }

    public BaseRepository(AppDbContext appDbContext)
    {
        AppDbContext = appDbContext;
    }
}