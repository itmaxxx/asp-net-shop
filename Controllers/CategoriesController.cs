using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asp_net_shop.Models;
using asp_net_shop.ViewModels;
using Microsoft.EntityFrameworkCore;

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
		// @TODO: show error if no items in categgory
		public IActionResult Category(int id)
		{
			string categoryName = "Nothing found";
			List <Product> products = new List<Product>();
			
			if (id == 0)
			{
				var user = _ctx.Users.FirstOrDefault(user => user.Email == User.Identity.Name);

				_ctx.Roles.Load();

				if (user != null && user.Role.Name == "Administrator")
				{
					categoryName = "All items";
					products = _ctx.Products.ToList();
				}
			}
			else
			{
				var category = _ctx.Categories.FirstOrDefault(cat => cat.Id == id);

				if (category != null)
				{
					categoryName = category.Name;
				
					products = _ctx.Products.Where(prod => prod.CategoryId == id).ToList();
				}
			}

			return View("Category", new CategoryViewModel() { Name = categoryName, Products = products });
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
