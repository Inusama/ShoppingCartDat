using System.Collections.Generic;

namespace ShoppingCart.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }

        public List<Product> Products { get; set; }
    }
}