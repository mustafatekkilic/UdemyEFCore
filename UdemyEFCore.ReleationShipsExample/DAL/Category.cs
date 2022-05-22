using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyEFCore.ReleationShipsExample.DAL
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; } = new List<Product>(); // = new List<Product>(); eklemesi shadow prop ile kategori üzerinden
                                                                          // ürün eklemeye çalıştığımızda null exception düşmesin diye
    }
}
