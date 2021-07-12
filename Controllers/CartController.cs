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
			var cartItems = _ctx.Carts.Where(cart => cart.UserId == 1);
			List<CartProductViewModel> products = new List<CartProductViewModel>();

			foreach (var item in cartItems)
			{
				products.Add(new CartProductViewModel { Product = _ctx.Products.First(prod => prod.Id == item.ProductId), Quantity = item.Quantity });
			}

			return View("Index", products);
		}

		// @TODO: if item exist in cart just increase it's quantity
		[Authorize]
		[HttpPost]
		public IActionResult Add(int productId)
		{
			var user = _ctx.Users.First(user => user.Email == User.Identity.Name);

			_ctx.Carts.Add(new Cart { ProductId = productId, Quantity = 1, UserId = user.Id });
			_ctx.SaveChanges();

			var cartItems = _ctx.Carts.Where(cart => cart.UserId == 1);
			List<CartProductViewModel> products = new List<CartProductViewModel>();

			foreach (var item in cartItems)
			{
				products.Add(new CartProductViewModel { Product = _ctx.Products.First(prod => prod.Id == item.ProductId), Quantity = item.Quantity });
			}

			return View("Index", products);
		}

		[Authorize]
		[HttpPost]
		public IActionResult Remove(int productId)
		{
			var user = _ctx.Users.First(user => user.Email == User.Identity.Name);
			var cartItem = _ctx.Carts.FirstOrDefault(item => item.UserId == user.Id && item.ProductId == productId);

			if (cartItem != null)
			{
				_ctx.Carts.Remove(cartItem);
				_ctx.SaveChanges();
			}

			var cartItems = _ctx.Carts.Where(cart => cart.UserId == 1);
			List<CartProductViewModel> products = new List<CartProductViewModel>();

			foreach (var item in cartItems)
			{
				products.Add(new CartProductViewModel { Product = _ctx.Products.First(prod => prod.Id == item.ProductId), Quantity = item.Quantity });
			}

			return View("Index", products);
		}
	}
}
