using Microsoft.AspNetCore.Mvc;
using MvcSampleAddService.Models;
using System.Diagnostics;
using MvcSampleAddService.Services;

namespace MvcSampleAddService.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ITimeService _timeService;

		public HomeController(ILogger<HomeController> logger, ITimeService timeService)
		{
			_logger = logger;
			_timeService = timeService;
		}

		public IActionResult Index()
		{
			var curTime = _timeService.GetTime();

			ViewBag.Message = $"Сейчас {curTime}";

			_logger.LogInformation($"Обращение к Index page. Время {curTime}");

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