using MvcSampleHttpClient.Services;

namespace MvcSampleHttpClient
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			builder.Services.Configure<WeatherServiceOptions>(
				builder.Configuration.GetSection("WeatherServiceOptions"));

			builder.Services.AddHttpClient<IWeatherService, WeatherService>(client =>
				{
					client.BaseAddress = new Uri("https://api.openweathermap.org");
					client.Timeout = TimeSpan.FromSeconds(120);
				})
				.SetHandlerLifetime(TimeSpan.FromMinutes(5));  //Set lifetime to five minutes

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