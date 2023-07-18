using Microsoft.AspNetCore.Mvc;

namespace LabExamSolution.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> products = new List<Product>
    {
        new Product { ProductId = 101, ProductName = "Harry Porter", Rate = 10.00M, Description = "descA", CategoryName = "Books" },
        new Product { ProductId = 102, ProductName = "Percy Jackson", Rate = 20.00M, Description = "descB", CategoryName = "Books" },
        new Product { ProductId = 103, ProductName = "Pen", Rate = 30.00M, Description = "descC", CategoryName = "Stationery" },
        new Product { ProductId = 104, ProductName = "Marker", Rate = 30.00M, Description = "descD", CategoryName = "Stationery" }
    };

        public ActionResult Index()
        {
            return View(products);
        }

        public ActionResult Edit(int productId)
        {
            var product = products.FirstOrDefault(p => p.ProductId == productId);
            if (product == null)
            {
                return View();
            }
            return View(product);
        }

        [HttpPost]
        public ActionResult Update(Product product)
        {
            if (ModelState.IsValid)
            {
                var existingProduct = products.FirstOrDefault(p => p.ProductId == product.ProductId);
                if (existingProduct != null)
                {
                    existingProduct.ProductName = product.ProductName;
                    existingProduct.Rate = product.Rate;
                    existingProduct.Description = product.Description;
                    existingProduct.CategoryName = product.CategoryName;
                }
                return RedirectToAction("Index");
            }
            return View("Edit", product);
        }

        public ActionResult Delete(int productId)
        {
            var product = products.FirstOrDefault(p => p.ProductId == productId);
            if (product == null)
            {
                return View();
            }
            return View(product);
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(int productId)
        {
            var product = products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                products.Remove(product);
            }
            return RedirectToAction("Index");
        }
    }
}