using ShoppingCart.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace ShoppingCart.DAL
{
    public class DataInitialization : DropCreateDatabaseIfModelChanges<ShoppingCartContext>
    {
        protected override void Seed(ShoppingCartContext context)
        {
            var categories = new List<Category> {
                new Category
                {
                    CategoryID = 1,
                    Title = "CPUs",
                    ImageUrl = "~/Images/CategoryCPUs.png"

                },
                new Category
                {
                    CategoryID = 2,
                    Title = "Memory",
                    ImageUrl = "~/Images/CategoryMemory.png"
                },
                new Category
                {
                    CategoryID = 3,
                    Title = "Graphics Cards",
                    ImageUrl = "~/Images/CategoryGraphicsCards.png"
                },
            };
            categories.ForEach(c => context.Categories.Add(c));


            var products = new List<Product> {
                new Product
                {
                    ProductID = 1,
                    Title = "R7",
                    LongDescription = "R7 long description...",
                    ShortDescription ="R7 short description...",
                    ImageUrl="~/Images/ProductR7.png",
                    Price = 99.9,
                    CategoryID = 1
               },
                new Product
                {
                   ProductID = 2,
                    Title = "AMD 2000",
                    LongDescription = "AMD 2000 long description...",
                    ShortDescription ="AMD 2000 description...",
                    ImageUrl="~/Images/ProductAMD2000.png",
                    Price = 75.0,
                    CategoryID = 1
               },
                new Product
                {
                    ProductID = 3,
                    Title = "Ultra Core i9",
                    LongDescription = "Ultra Core i9 long description...",
                    ShortDescription ="Ultra Core i9 description...",
                    ImageUrl="~/Images/ProductUltraCorei9.png",
                    Price = 499.95,
                    CategoryID = 1
                },
                new Product
                {
                   ProductID = 4,
                    Title = "Kingston Ultra Fury",
                    LongDescription = "Kingston Ultra Fury long description...",
                    ShortDescription ="Kingston Ultra Fury description...",
                    ImageUrl="~/Images/ProductKingstonUltraFury.png",
                    Price = 100.00,
                    CategoryID = 2
                },
                new Product
                {
                     ProductID = 5,
                    Title = "ZEDRAM",
                    LongDescription = "ZEDRAM long description...",
                    ShortDescription ="ZEDRAM description...",
                    ImageUrl="~/Images/ProductZEDRAM.png",
                    Price = 150.00,
                    CategoryID = 2
                },
                new Product
                {
                     ProductID = 5,
                    Title = "DDRZ",
                    LongDescription = "DDRZ long description...",
                    ShortDescription ="DDRZ description...",
                    ImageUrl="~/Images/ProductDDRZ.png",
                    Price = 400.00,
                    CategoryID = 2
                },
                new Product
                {
                    ProductID = 5,
                    Title = "ATI 5.0 GC",
                    LongDescription = "ATI 5.0 GC long description...",
                    ShortDescription ="ATI 5.0 GC description...",
                    ImageUrl="~/Images/ProductATI.5.0.GC.png",
                    Price = 350.00,
                    CategoryID = 3
                },
                new Product
                {
                    ProductID=6,
                    Title = "Nvidia Revolution X1 GFX",
                    LongDescription = "Nvidia Revolution X1 GFX long description...",
                    ShortDescription ="Nvidia Revolution X1 GFX description...",
                    ImageUrl="~/Images/ProductNvidiaRevolutionX1GFX.png",
                    Price = 700.00,
                    CategoryID = 3
                },

            };
            products.ForEach(b => context.Products.Add(b));
            context.SaveChanges();
        }
    }
}