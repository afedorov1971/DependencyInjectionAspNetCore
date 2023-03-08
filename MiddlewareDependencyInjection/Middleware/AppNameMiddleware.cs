namespace MiddlewareDependencyInjection.Middleware
{
	public class AppNameMiddleware
	{
		private readonly RequestDelegate _next;
		public AppNameMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task InvokeAsync(HttpContext context, IHostEnvironment env)
		{
			await context.Response.WriteAsync($"<p>Приложение {env.ApplicationName}<p>");
			await _next(context);
		}
	}
}
