using System.Data.Entity;
using System.Linq;

namespace ShoppingCart.Models
{
    public class ShoppingCartContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}