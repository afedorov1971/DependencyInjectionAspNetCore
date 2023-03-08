namespace MiddlewareDependencyInjection.Middleware
{
	public class SetContentTypeMiddleware
	{
		private readonly RequestDelegate _next;
		public SetContentTypeMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			context.Response.ContentType = "text/html;charset=utf-8";
			// Избавляемся от запроса к favicon.ico
			await context.Response.WriteAsync("<head><link rel='icon' href='data:,'/></head>");
			await _next(context);
		}
	}
}
