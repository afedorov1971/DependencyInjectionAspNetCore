using ScopedService.Services;

namespace ScopedService.Middleware
{
	public class StartTimeMiddleware
	{
		private readonly RequestDelegate _next;
		public StartTimeMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task InvokeAsync(HttpContext context, ITimeService time)
		{
			await context.Response.WriteAsync($"<p>Время {time.GetTime()}<p>");
			await Task.Delay(2000);
			await _next(context);
		}
	}
}
