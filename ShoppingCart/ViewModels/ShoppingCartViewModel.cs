using ShoppingCart.Models;
using System.Collections.Generic;

namespace ShoppingCart.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<CartItem> CartItems { get; set; }
        public double CartTotal { get; set; }
    }
}