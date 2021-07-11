using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using asp_net_shop.Models;

namespace asp_net_shop.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private ApplicationContext _appContext;

		public HomeController(ILogger<HomeController> logger, ApplicationContext appContext)
		{
			_logger = logger;
			_appContext = appContext;
		}

		public IActionResult Index()
		{
			return View();
		}

		[Authorize(Roles = "Administrator")]
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
