﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_net_shop.Models
{
    public class Cart
    {
        public int Id { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();
    }
}
