using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyEFCore.ReleationShipsExample.DAL
{
    public class Product
    {

        #region One to Many

        //public int ProductId { get; set; }
        //public string Name { get; set; }
        //public string Description { get; set; }
        //public int Stock { get; set; }
        //public decimal Price { get; set; }
        ///// <summary>
        ///// Shadow Property ---- Veritabanına CategoryId eklendi, burada olmadığı herhangi bir product eklemek istediğimiz category üzerinden ilerlememiz gerekiyor
        ///// bu bize DDD için fayda sağlıyor. Örnek bir dezavantaj vermek gerekirse product eklemek istediğinde senden manuel bir categoryid alır, doğru girip girmediğin
        ///// meçhul fakat bu yazım da category üzerinden gideceğin için, yanlış yapma oranı daha düşük. (Kodlama program.cs altında)
        ///// </summary>
        //public Category Category { get; set; }

        ////----
        ////public int CategoryId { get; set; } //Convensions ef core best practices yapısı ---- Migrations sildik, fluent api ile tekrar tasarladık.
        ////AppDbContext altında fluent kodlamaları
        //public int Category_Id { get; set; } //Fluent API
        ////Navigation Property
        ////[ForeignKey("Category_Id")] // Attributes migration kaldırdık yine 
        ////public Category Category { get; set; }


        #endregion

        #region One to One - EF Core Convensions

        //public int Id { get; set; }
        //public string Name { get; set; }
        //public decimal Price { get; set; }
        //public int Stock { get; set; }
        //public int Barcode { get; set; }
        //public ProductFeature ProductFeature { get; set; }

        #endregion

        #region One to One - Ef Core Fluent Api
        //public int ProductId { get; set; }
        //public string Name { get; set; }
        //public decimal Price { get; set; }
        //public int Stock { get; set; }
        //public int Barcode { get; set; }
        //public int CategoryId { get; set; }
        //public Category Category { get; set; }
        //public ProductFeature ProductFeature { get; set; }



        #endregion

        #region Delete Behaviors

        //[DatabaseGenerated(DatabaseGeneratedOption.None)] //Identity özelliğini kaldırır, manuel giriş yapmak gerekir.
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Kdv { get; set; }
        public int Stock { get; set; }
        public int Barcode { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal PriceKdv { get; set; }


        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]//Sadece insert işleminde CreatedDate atacak, update işleminde herhangi bir şey yansımayacak
        //public DateTime? CreatedDate { get; set; } = DateTime.Now;
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)] // Insert veya update de işlem yapmaz
        //public DateTime? LastAccessDate { get; set; }

        //Database Generated Attribute için yorum satırı - example
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        #endregion

    }
}
