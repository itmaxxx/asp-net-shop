using asp_net_shop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_net_shop.Controllers
{
	public class CartController : Controller
	{
		private ApplicationContext _ctx;

		public CartController(ApplicationContext ctx)
		{
			_ctx = ctx;
		}

		[Authorize]
		public IActionResult Index()
		{
			var carts = _ctx.Carts.Where(cart => cart.UserId == 1);

			return View("Index");
		}

		[Authorize]
		[HttpPost]
		public IActionResult Add(int productId)
		{
			var user = _ctx.Carts.Where(cart => cart.UserId == 1);


			if (user != null)
			{
				return View("Index");
			}
			else
			{
				return View("Index");
			}
		}
	}
}
