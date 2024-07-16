using Ardalis.Result;
using IResult = Microsoft.AspNetCore.Http.IResult;

namespace WebApi.Extensions;

public static class ResultExtensions
{
    public static IResult ToHttpResult<T>(this Result<T> result)
    {
        return result.Status switch
        {
            ResultStatus.Ok => Results.Ok(result.Value),
            ResultStatus.NotFound => Results.NotFound(result.Errors),
            ResultStatus.Invalid => Results.BadRequest(result.ValidationErrors),
            ResultStatus.Unauthorized => Results.Unauthorized(),
            ResultStatus.Forbidden => Results.Forbid(),
            _ => Results.StatusCode(500)
        };
    }
}