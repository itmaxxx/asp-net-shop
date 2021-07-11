using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asp_net_shop.Models;

namespace asp_net_shop.Controllers
{
	public class CategoriesController : Controller
	{
		private ApplicationContext _ctx;

		public CategoriesController(ApplicationContext ctx)
		{
			_ctx = ctx;
		}

		public IActionResult Index()
		{
			return View(_ctx.Categories.ToList());
		}
	}
}
