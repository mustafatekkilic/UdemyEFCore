using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyEFCore.ReleationShipsExample.DAL
{
    public class ProductFeature
    {
        #region One to One PrimaryKey != ForeignKey 

        //public int ProductFeatureId { get; set; }
        //public int Width { get; set; }
        //public int Height { get; set; }
        //public string Color { get; set; }

        ////Convensions
        ////public int ProductId { get; set; }

        //public int ProductRef_Id { get; set; }
        //[ForeignKey("ProductRef_Id")]
        //public Product Product { get; set; }

        #endregion

        #region One to One PrimaryKey = ForeignKey
        [ForeignKey("Product")]
        public int ProductFeatureId { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Color { get; set; }

        public Product Product { get; set; }


        #endregion


    }
}
