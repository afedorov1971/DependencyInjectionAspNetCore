using MiddlewareDependencyInjection.Middleware;

namespace MiddlewareDependencyInjection
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			var app = builder.Build();

			app.UseMiddleware<SetContentTypeMiddleware>();
			app.UseMiddleware<AppNameMiddleware>();
			app.UseMiddleware<EnvNameMiddleware>();

			app.MapGet("/", () => "<p>Привет</p>");

			app.Run();
		}
	}
}