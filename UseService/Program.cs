namespace UseService
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			var app = builder.Build();

			app.MapGet("/", async context =>
			{
				context.Response.ContentType = "text/html;charset=utf-8";

				var env = context.RequestServices.GetRequiredService<IHostEnvironment>();

				await context.Response.WriteAsync($"Привет из приложения {env.ApplicationName}, среда {env.EnvironmentName}");
			});

			app.Run();
		}
	}
}