using System.ComponentModel.DataAnnotations;

namespace UdemyEFCore.Concurrency.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        //[Timestamp] -- FluentApi olarak verildi. AppDbContext
        public byte[] RowVersion { get; set; }
    }
}
