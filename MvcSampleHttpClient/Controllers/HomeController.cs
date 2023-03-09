using Microsoft.AspNetCore.Mvc;
using MvcSampleHttpClient.Models;
using System.Diagnostics;
using MvcSampleHttpClient.Services;

namespace MvcSampleHttpClient.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IWeatherService _weatherService;

		public HomeController(ILogger<HomeController> logger, IWeatherService weatherService)
		{
			_logger = logger;
			_weatherService = weatherService;
		}

		public async Task<IActionResult> Index()
		{
			var result = await _weatherService.GetInfoAsync();

			var message = result == null ? "Не удалось получить прогноз погоды" : $"В г.{result.CityName} температура {result.TempCelsius}° ";

			ViewBag.Message = message;
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}