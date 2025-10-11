using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Ecommerce.CORE.Core.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        

    }

    public class ProductFavoriteDTO
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public decimal? Price { get; set; }
        public int Stock { get; set; }

    }
}
