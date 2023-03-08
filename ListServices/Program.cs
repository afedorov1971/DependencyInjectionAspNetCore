using System.Text;

namespace ListServices
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			var app = builder.Build();

			app.MapGet("/", async context =>
			{
				var sb = new StringBuilder();

				sb.Append("<h1>Список сервисов</h1>");
				sb.Append("<table><thead>");
				sb.Append("<tr><th>Тип</th><th>Время жизни</th></tr>");
				sb.Append("</thead><tbody>");

				foreach (var s in builder.Services)
				{
					sb.Append("<tr>");
					sb.Append((string?) $"<td>{s.ServiceType.FullName}</td>");
					sb.Append((string?) $"<td>{s.Lifetime}</td>");
					sb.Append("</tr>");
				}

				sb.Append("</tbody></table>");

				context.Response.ContentType = "text/html;charset=utf-8";

				await context.Response.WriteAsync(sb.ToString());
			});

			app.Run();
		}
	}
}