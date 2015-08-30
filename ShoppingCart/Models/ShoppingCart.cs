using System.Linq;

namespace ShoppingCart.Models
{
    public class ShoppingCart
    {
        ShoppingCartContext storeDB = new ShoppingCartContext();

        CartService cartService = new CartService();

        string cartSessionID { get; set; }

        public Cart GetCart(string sessionID)
        {
            var cart = cartService.GetBySessionID(sessionID);
            cartSessionID = cart.SessionID;
            return cart;
        }

        public void AddToCart(Product product)
        {
            // Get the matching cart and album instances
            var cart = GetCart(cartSessionID);
            var cartItem = cart.CartItems.SingleOrDefault(i => i.ProductID == product.ProductID);

            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists
                cartItem = new CartItem
                {
                    ProductID = product.ProductID,
                    CartID = cart.ID,
                    Quantity = 1,
                };
                storeDB.CartItems.Add(cartItem);
            }
            else
            {
                // If the item does exist in the cart, 
                // then add one to the quantity
                cartItem.Quantity++;
            }
            // Save changes
            storeDB.SaveChanges();
        }

        public int RemoveFromCart(int id)
        {
            // Get the cart
            var cart = GetCart(cartSessionID);
            var cartItem = cart.CartItems.Single(i => i.ProductID == id);

            int itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.Quantity > 1)
                {
                    cartItem.Quantity--;
                    itemCount = cartItem.Quantity;
                }
                else
                {
                    storeDB.CartItems.Remove(cartItem);
                    //storeDB.Carts.Remove(cartItem);
                }
                // Save changes
                storeDB.SaveChanges();
            }
            return itemCount;
        }

        public void EmptyCart()
        {
            // Get the cart
            var cart = GetCart(cartSessionID);
            var cartItems = storeDB.CartItems.Where(c => c.CartID == cart.ID);

            foreach (var cartItem in cartItems)
            {
                storeDB.CartItems.Remove(cartItem);
            }
            // Save changes
            storeDB.SaveChanges();
        }

        public int GetCount()
        {
            var cart = GetCart(cartSessionID);
            // Get the count of each item in the cart and sum them up
            int count = (from cartItems in storeDB.CartItems
                         where cartItems.CartID == cart.ID
                         select (int)cartItems.Quantity).Sum();
            // Return 0 if all entries are null
            return count;
        }

        public double GetTotal()
        {
            var cart = GetCart(cartSessionID);
            // Multiply album price by count of that album to get 
            // the current price for each of those albums in the cart
            // sum all album price totals to get the cart total
            double total = (from cartItems in storeDB.CartItems
                            where cartItems.CartID == cart.ID
                            select (int)cartItems.Quantity *
                            cartItems.Product.Price).Sum();
            return total;
        }
    }
}