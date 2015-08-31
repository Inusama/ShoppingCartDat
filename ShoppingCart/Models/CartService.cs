using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Models
{
    public class CartService
    {
        ShoppingCartContext storeDB;

        public CartService(ShoppingCartContext storeDB)
        {
            this.storeDB = storeDB;
        }

        public Cart GetBySessionID(string sessionID)
        {
            var cart = storeDB.Carts.
            Include("CartItems").
            Where(c => c.SessionID == sessionID).
            SingleOrDefault();

            cart = CreateCartIfItDoesntExist(sessionID, cart);

            return cart;
        }

        private Cart CreateCartIfItDoesntExist(string sessionID, Cart cart)
        {
            if (cart == null)
            {
                cart = new Cart { SessionID = sessionID, CartItems = new List<CartItem>() };
                storeDB.Carts.Add(cart);
                storeDB.SaveChanges();
            }
            return cart;
        }
    }
}