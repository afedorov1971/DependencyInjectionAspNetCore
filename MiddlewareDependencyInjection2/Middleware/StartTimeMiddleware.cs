using MiddlewareDependencyInjection2.Services;

namespace MiddlewareDependencyInjection2.Middleware
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
			await _next(context);
		}
	}
}
