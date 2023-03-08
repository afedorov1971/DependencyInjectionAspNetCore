using ScopedService.Middleware;
using ScopedService.Services;

namespace ScopedService
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddScoped<ITimeService, TimeService>();

			var app = builder.Build();

			app.UseMiddleware<SetContentTypeMiddleware>();

			app.UseMiddleware<StartTimeMiddleware>();
			app.UseMiddleware<AppNameMiddleware>();
			app.UseMiddleware<EnvNameMiddleware>();

			app.MapGet("/", () => "<p>Привет</p>");

			app.Run();
		}
	}
}