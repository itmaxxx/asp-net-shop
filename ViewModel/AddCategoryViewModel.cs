using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace asp_net_shop.ViewModels
{
	public class AddCategoryViewModel
	{
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Photo { get; set; }
    }
}
