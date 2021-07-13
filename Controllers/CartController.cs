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

		private List<CartProductViewModel> GetUserCart()
		{
			var user = _ctx.Users.First(user => user.Email == User.Identity.Name);
			var cartItems = _ctx.Carts.Where(cart => cart.UserId == user.Id);
			List<CartProductViewModel> products = new List<CartProductViewModel>();

			foreach (var item in cartItems)
			{
				products.Add(new CartProductViewModel { Product = _ctx.Products.First(prod => prod.Id == item.ProductId), Quantity = item.Quantity });
			}

			return products;
		}

		[Authorize]
		public IActionResult Index()
		{
			return View("Index", GetUserCart());
		}

		[Authorize]
		[HttpPost]
		public IActionResult Add(int productId, int quantity = 1)
		{
			var user = _ctx.Users.First(user => user.Email == User.Identity.Name);
			var cartItem = _ctx.Carts.FirstOrDefault(item => item.UserId == user.Id && item.ProductId == productId);

			if (cartItem != null)
			{
				cartItem.Quantity += quantity;
				
				if (cartItem.Quantity <= 0)
				{
					_ctx.Carts.Remove(cartItem);
				}
				else
				{
					_ctx.Carts.Update(cartItem);
				}
			}
			else
			{
				_ctx.Carts.Add(new Cart { ProductId = productId, Quantity = quantity, UserId = user.Id });
			}

			_ctx.SaveChanges();

			return View("Index", GetUserCart());
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

			return View("Index", GetUserCart());
		}
	}
}
