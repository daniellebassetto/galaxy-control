namespace GalaxyControl.Middleware;

public class RedirectToLoginMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (UnauthorizedAccessException)
        {
            context.Response.Redirect("/Login/Index");
        }
    }
}