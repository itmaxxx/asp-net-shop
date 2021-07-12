using asp_net_shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_net_shop.ViewModels
{
	public class CategoryViewModel
	{
        public string Name { get; set; }
        public List<Product> Products { get; set; }

        public CategoryViewModel()
        {
            Products = new List<Product>();
        }
    }
}
