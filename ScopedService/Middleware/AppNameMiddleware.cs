using ScopedService.Services;

namespace ScopedService.Middleware
{
	public class AppNameMiddleware
	{
		private readonly RequestDelegate _next;
		public AppNameMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task InvokeAsync(HttpContext context, IHostEnvironment env, ITimeService time)
		{
			await context.Response.WriteAsync($"<p>Приложение {env.ApplicationName}.Время {time.GetTime()}<p>");
			await Task.Delay(2000);

			await _next(context);
		}
	}
}
