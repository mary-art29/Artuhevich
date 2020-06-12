using Microsoft.AspNetCore.Builder;
using WebLabs.Middleware;
namespace WebLabs.Extensions
{
    public static class AppExtensions
    {
        public static IApplicationBuilder UseFileLogging(this
        IApplicationBuilder app)
        => app.UseMiddleware<LogMiddleware>();
    }
}