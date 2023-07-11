namespace Notes.API.Shared.Services.Communication;

public class BaseResponse<TEntity>
{
    public TEntity? Resource { get; set; }
    public string Message { get; set; }
    public bool Success { get; set; }

    public BaseResponse(TEntity resource)
    {
        Resource = resource;
        Message = string.Empty;
        Success = true;
    }

    public BaseResponse(string message)
    {
        Resource = default;
        Message = message;
        Success = false;
    }

}