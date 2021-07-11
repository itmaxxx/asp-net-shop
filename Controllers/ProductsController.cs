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

            return View(_ctx.Products.ToList());
        }

        // @TODO: rewrite with normal view
        public async Task<IActionResult> Product(int Id)
        {
            var product = await _ctx.Products.FirstOrDefaultAsync(prod => prod.Id == Id);

            if (product != null)
            {
                return PartialView("_Product", product);
            }

            else return PartialView("Failed to load product");
        }
    }
}
