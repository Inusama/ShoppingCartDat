using MvcMusicStore.ViewModels;
using ShoppingCart.Models;
using ShoppingCart.ViewModels;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Controllers
{
    public class ShoppingCartController : Controller
    {

        // GET: ShoppingCart
        public ActionResult Index()
        {
            ShoppingCart.Models.ShoppingCart shoppingCart = new ShoppingCart.Models.ShoppingCart();
            var cart = shoppingCart.GetCart(this.HttpContext.Session.SessionID);

            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.CartItems,
                //CartTotal = cart.GetTotal()
            };
            // Return the view
            return View(viewModel);
        }

        // GET: /ShoppingCart/AddToCart/5
        public ActionResult AddToCart(int id)
        {
            ShoppingCart.Models.ShoppingCart shoppingCart = new ShoppingCart.Models.ShoppingCart();
            var cart = shoppingCart.GetCart(HttpContext.Session.SessionID);

            ShoppingCartContext storeDB = shoppingCart.getDB();
            // Retrieve the album from the database
            var addedItem = storeDB.Products.Single(p => p.ProductID == id);

            // Add it to the shopping cart


            shoppingCart.AddToCart(addedItem);

            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }

        // AJAX: /ShoppingCart/RemoveFromCart/5
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            // Remove the item from the cart
            ShoppingCart.Models.ShoppingCart shoppingCart = new ShoppingCart.Models.ShoppingCart();
            var cart = shoppingCart.GetCart(HttpContext.Session.SessionID);
            ShoppingCartContext storeDB = shoppingCart.getDB();

            // Get the name of the album to display confirmation
            string produdctTitle = storeDB.CartItems.Single(i => i.ProductID == id).Product.Title;

            // Remove from cart
            int itemCount = shoppingCart.RemoveFromCart(id);

            // Display the confirmation message
            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(produdctTitle) +
                    " has been removed from your shopping cart.",
                CartTotal = shoppingCart.GetTotal(),
                CartCount = shoppingCart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }
    }
}