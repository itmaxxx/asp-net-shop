using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_net_shop.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
		public string Photo { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
