using System.ComponentModel.DataAnnotations;

namespace API_Product.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImage { get; set; }
        public int CategoryId { get; set; }
    }
}
