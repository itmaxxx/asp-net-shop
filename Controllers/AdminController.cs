using asp_net_shop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_net_shop.Controllers
{
	public class AdminController : Controller
	{
		private ApplicationContext _ctx;

		public AdminController(ApplicationContext ctx)
		{
			_ctx = ctx;
		}

		[Authorize(Roles = "Administrator")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
