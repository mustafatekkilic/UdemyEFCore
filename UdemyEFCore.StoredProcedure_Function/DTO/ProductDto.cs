using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyEFCore.StoredProcedure_Function.DTO
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal DiscountPrice { get; set; }
        public string Barcode { get; set; }
        public string Url { get; set; }
        
    }
}
