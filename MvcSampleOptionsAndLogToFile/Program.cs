using MvcSampleOptionsAndLogToFile.Services;
using Serilog;

namespace MvcSampleOptionsAndLogToFile
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			builder.Services.AddTransient<ITimeService, TimeServiceWithOptions>();

			builder.Services.Configure<TimeOptions>(
				builder.Configuration.GetSection("TimeOptions"));

			var logger = new LoggerConfiguration()
				.WriteTo.File("./logs/log-.txt", rollingInterval: RollingInterval.Hour)
				.MinimumLevel.Information()
				.CreateLogger();

			builder.Logging.AddSerilog(logger);

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
			}
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}