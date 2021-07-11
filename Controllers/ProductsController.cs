using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using asp_net_shop.Models;

namespace asp_net_shop.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationContext _ctx;

        public ProductsController(ApplicationContext ctx)
        {
            _ctx = ctx;
        }

        //[Authorize]
        public IActionResult Index()
        {
            _ctx.Categories.Load();

            return View(new CategoryModel() { Name = "All products", Products = _ctx.Products.ToList() });
        }

        // @TODO: check if category with this id doesn't exist
        // @TODO: replace to category controller and view ???
        public IActionResult Category(int id)
        {
            var category = _ctx.Categories.First(cat => cat.Id == id);

			var products = _ctx.Products.Where(prod => prod.CategoryId == id).ToList();

            return View("Index", new CategoryModel() { Name = category.Name, Products = products });
        }

        // @TODO: rewrite with normal view
        public IActionResult Product(int id)
        {
            var product = _ctx.Products.FirstOrDefault(prod => prod.Id == id);

            if (product != null)
            {
                return PartialView("_Product", product);
            }

            else return PartialView("Failed to load product");
        }
    }
}
