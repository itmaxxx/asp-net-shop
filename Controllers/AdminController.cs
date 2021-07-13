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

		[Authorize(Roles = "Administrator")]
		public IActionResult EditProduct(int id)
		{
			var product = _ctx.Products.FirstOrDefault(prod => prod.Id == id);

			ViewData["Categories"] = _ctx.Categories.ToList();

			return View(product);
		}

		[Authorize(Roles = "Administrator")]
		[HttpPost]
		public IActionResult EditProduct(Product product)
		{
			_ctx.Products.Update(product);
			_ctx.SaveChanges();

			return RedirectToAction("Index", "Products", new { id = product.Id });
		}

		[Authorize(Roles = "Administrator")]
		public IActionResult EditCategory(int id)
		{
			var category = _ctx.Categories.FirstOrDefault(cat => cat.Id == id);

			return View(category);
		}

		[Authorize(Roles = "Administrator")]
		[HttpPost]
		public IActionResult EditCategory(Category category)
		{
			_ctx.Categories.Update(category);
			_ctx.SaveChanges();

			return RedirectToAction("Category", "Categories", new { id = category.Id });
		}

		[Authorize(Roles = "Administrator")]
		[HttpPost]
		public IActionResult DeleteProduct(int productId)
		{
			var product = _ctx.Products.FirstOrDefault(prod => prod.Id == productId);

			_ctx.Products.Remove(product);
			_ctx.SaveChanges();

			return RedirectToAction("Category", "Categories", new { id = product.CategoryId });
		}

		[Authorize(Roles = "Administrator")]
		[HttpPost]
		public IActionResult DeleteCategory(int categoryId)
		{
			var category = _ctx.Categories.FirstOrDefault(cat => cat.Id == categoryId);

			_ctx.Categories.Remove(category);
			_ctx.SaveChanges();

			return RedirectToAction("Index", "Categories");
		}
	}
}
