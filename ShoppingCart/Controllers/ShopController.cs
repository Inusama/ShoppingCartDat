using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public string Index()
        {
            return "Hello from Shop.Index()";
        }

        // GET: /Shop/Browse
        public string Browse(string category)
        {
            string message = HttpUtility.HtmlEncode("Shop.Browse, Category = " + category);
            return message;
        }

        // GET: /Shop/Details
        public string Details(int id)
        {
            string message = "Shop.Details, ID = " + id;
            return message;
        }
    }
}