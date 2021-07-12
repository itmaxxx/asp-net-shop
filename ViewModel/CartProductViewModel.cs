using asp_net_shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_net_shop.ViewModels
{
	public class CartProductViewModel
	{
		public Product Product { get; set; }
		public int Quantity { get; set; }
	}
}
