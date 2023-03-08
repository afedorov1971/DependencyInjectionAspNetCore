namespace MiddlewareDependencyInjection2.Middleware
{
	public class EnvNameMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly IHostEnvironment _env;

		public EnvNameMiddleware(RequestDelegate next, IHostEnvironment env)
		{
			_next = next;
			_env = env;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			await context.Response.WriteAsync($"<p>Окружение {_env.EnvironmentName}<p>");
			await _next(context);
		}
	}
}
