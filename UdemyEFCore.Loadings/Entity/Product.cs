using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyEFCore.Loadings.Entity
{
    public class Product
    {
        public int Id { get; set; }
        //[Unicode(false)] nvarchar değil varchar yapar, veritabanında daha az yer kaplar
        public string Name { get; set; }
        public int Stock { get; set; }
        [Precision(9, 2)]
        public decimal Price { get; set; }
        //[NotMapped] Veritabanına yansımaz
        public string Barcode { get; set; }
        public int CategoryId { get; set; }

        //Entity Prop için eklendi
        //[Column(TypeName = "nvarchar(200)")]
        //public string Url { get; set; }

        public virtual Category Category { get; set; }
        public virtual ProductFeatures ProductFeatures { get; set; }
    }
}
