namespace TransientService.Middleware
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
			await _next(context);
		}
	}
}
