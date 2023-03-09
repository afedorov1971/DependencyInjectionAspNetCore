using MvcSample.Services;
using Serilog;

namespace MvcSample
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			builder.Services.AddTransient<ITimeService, TimeService>();

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