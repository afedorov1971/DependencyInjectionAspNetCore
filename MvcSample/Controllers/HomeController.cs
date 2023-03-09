using Microsoft.AspNetCore.Mvc;
using MvcSample.Models;
using System.Diagnostics;
using MvcSample.Services;

namespace MvcSample.Controllers
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
			_logger.LogInformation($"Обращение к Index page. Время {_timeService.GetTime()}" );
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