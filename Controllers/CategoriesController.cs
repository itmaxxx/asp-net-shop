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

		// @TODO: replace to category controller and view ???
		// @TODO: check if category with this id doesn't exist
		public IActionResult Category(int id)
		{
			var category = _ctx.Categories.First(cat => cat.Id == id);

			var products = _ctx.Products.Where(prod => prod.CategoryId == id).ToList();

			return View("Category", new CategoryModel() { Name = category.Name, Products = products });
		}
	}
}
