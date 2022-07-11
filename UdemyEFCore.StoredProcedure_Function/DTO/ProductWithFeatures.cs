using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyEFCore.StoredProcedure_Function.DTO
{
    public class ProductWithFeatures
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Width { get; set; }  
        public int Height { get; set; }
    }
}
