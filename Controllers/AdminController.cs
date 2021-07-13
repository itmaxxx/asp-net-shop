using asp_net_shop.Models;
using asp_net_shop.ViewModels;
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

		[Authorize(Roles = "Administrator")]
		public IActionResult AddProduct()
		{
			ViewData["Categories"] = _ctx.Categories.ToList();

			return View();
		}

		[Authorize(Roles = "Administrator")]
		[HttpPost]
		public IActionResult AddProduct(AddProductViewModel model)
		{
			if (ModelState.IsValid)
			{
				var product = new Product
				{
					Name = model.Name,
					Description = model.Description,
					Price = model.Price,
					CategoryId = model.CategoryId,
					Photo = model.Photo
				};

				_ctx.Products.Add(product);
				_ctx.SaveChanges();

				return RedirectToAction("Index");
			}

			ModelState.AddModelError("", "Please fix following errors");
			ViewData["Categories"] = _ctx.Categories.ToList();

			return View();
		}

		[Authorize(Roles = "Administrator")]
		public IActionResult AddCategory()
		{
			return View();
		}

		[Authorize(Roles = "Administrator")]
		[HttpPost]
		public IActionResult AddCategory(AddCategoryViewModel model)
		{
			if (ModelState.IsValid)
			{
				var category = new Category
				{
					Name = model.Name,
					Photo = model.Photo
				};

				_ctx.Categories.Add(category);
				_ctx.SaveChanges();

				return RedirectToAction("Index");
			}

			ModelState.AddModelError("", "Please fix following errors");

			return View();
		}
	}
}
