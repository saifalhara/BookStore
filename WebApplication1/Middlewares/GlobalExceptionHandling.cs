using Microsoft.AspNetCore.Mvc;

namespace BookStore.Middlewares;

public class GlobalExceptionHandling(RequestDelegate _next)
{
    public virtual async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            ProblemDetails problemDetails = new ProblemDetails()
            {
                Title = "Internal Server Error!",
                Detail = ex.Message,
                Status = StatusCodes.Status500InternalServerError
            };
            await context.Response.WriteAsJsonAsync(problemDetails);
        }

    }
}
