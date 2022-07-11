using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyEFCore.MultipleDbContext.DTO
{
    public class PDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        
        public decimal Price { get; set; }
        
        public decimal DiscountPrice { get; set; }
        
    }
}
