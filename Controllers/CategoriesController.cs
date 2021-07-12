using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asp_net_shop.Models;
using asp_net_shop.ViewModels;

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

		// @TODO: show error if category with this id doesn't exist
		// @TODO: show error if not items in categgory
		public IActionResult Category(int id)
		{
			var category = _ctx.Categories.First(cat => cat.Id == id);

			var products = _ctx.Products.Where(prod => prod.CategoryId == id).ToList();

			return View("Category", new CategoryViewModel() { Name = category.Name, Products = products });
		}

		[HttpPost]
		public IActionResult Search(string query)
		{
			var lowerQuery = query.ToLower();
			var products = _ctx.Products.Where(prod => prod.Name.ToLower().Contains(lowerQuery)).ToList();

			return View("Category", new CategoryViewModel() { Name = $"Search results for \"{query}\"", Products = products });
		}
	}
}
