using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyEFCore.MultipleDbContext.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        [Precision(9, 2)]
        public decimal Price { get; set; }
        [Precision(9, 2)]
        public decimal DiscountPrice { get; set; }
        public string Barcode { get; set; }
        public string Url { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ProductFeatures ProductFeatures { get; set; }
    }
}
