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

        // @TODO: show error if item with this is doesn't exist
        public IActionResult Index(int id)
        {
            var product = _ctx.Products.FirstOrDefault(prod => prod.Id == id);

            if (product != null)
            {
                return View(product);
            }
                
            return View();
        }
    }
}
