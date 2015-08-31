using ShoppingCart.Models;
using System.Linq;
using System.Web.Mvc;

namespace ShoppingCart.Controllers
{
    public class ShopController : Controller
    {
        ShoppingCartContext storeDB = new ShoppingCartContext();

        // GET: Shop
        public ActionResult Index()
        {
            var categories = storeDB.Categories.ToList();
            return View(categories);

        }

        // GET: /Shop/Browse
        public ActionResult Browse(string category)
        {
            var categoryModel = storeDB.Categories.Include("Products").Single(g => g.Title == category);
            return View(categoryModel);
        }

        // GET: /Shop/Details
        public ActionResult Details(int id)
        {
            var product = storeDB.Products.Find(id);
            return View(product);
        }
    }
}