using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyEFCore.MultipleDbContext.DTO
{
    public class ProductEssential
    {
        public int Id { get; set; } // modelbuilder hasnokey()
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
