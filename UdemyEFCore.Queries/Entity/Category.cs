using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyEFCore.Queries.Entity
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public virtual List<Product> Product { get; set; } = new List<Product>();
    }
}
