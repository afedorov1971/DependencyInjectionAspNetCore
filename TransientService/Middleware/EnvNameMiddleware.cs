using TransientService.Services;

namespace TransientService.Middleware
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

		public async Task InvokeAsync(HttpContext context, ITimeService time)
		{
			await context.Response.WriteAsync($"<p>Окружение {_env.EnvironmentName}.Время {time.GetTime()}<p>");
			await Task.Delay(2000);
			await _next(context);
		}
	}
}
