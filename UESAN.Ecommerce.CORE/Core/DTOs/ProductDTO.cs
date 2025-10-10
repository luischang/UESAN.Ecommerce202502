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
        public string? Description { get; set; } 
        public decimal? UnitPrice { get; set; }
        public bool? IsActive { get; set; }
    }
    public class ProductCreateDTO
    {
        public string? Description { get; set; }
        public decimal? UnitPrice { get; set; }
    }
    public class ProductListDTO
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public decimal? UnitPrice { get; set; }
    }
}
