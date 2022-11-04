using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Final_Project.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepo _repo;

        public ProductController(IProductRepo repo)
        {
            _repo = repo;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var products = _repo.GetAllProducts();
            return View(products);
        }

        public IActionResult ViewProduct(int id)
        {
            var product = _repo.GetProduct(id);
            return View(product);
        }

        public IActionResult InsertProduct()
        {
            var prod = _repo.AssignCategory();
            return View(prod);
        }

        public IActionResult InsertProductToDatabase(Product productToInsert)
        {
            _repo.InsertProduct(productToInsert);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateProduct(int id)
        {
            Product prod = _repo.GetProduct(id);
            if (prod == null)
            {
                return View("ProductNotFound");
            }
            return View(prod);
        }

        public IActionResult UpdateProductToDatabase(Product product)
        {
            _repo.UpdateProduct(product);

            return RedirectToAction("ViewProduct", new { id = product.ProductID });
        }

        public IActionResult DeleteProduct(Product product)
        {
            _repo.DeleteProduct(product);
            return RedirectToAction("Index");
        }

        public IActionResult Pastries()
        {
            var pastries = _repo.Pastries();
            return View(pastries);
        }

        public IActionResult Cakes()
        {
            var cakes = _repo.Cakes();
            return View(cakes);
        }

        public IActionResult Cheesecakes()
        {
            var cheesecakes = _repo.Cheesecakes();
            return View(cheesecakes);
        }

        public IActionResult Pies()
        {
            var pies = _repo.Pies();
            return View(pies);
        }

        public IActionResult Specials()
        {
            var specials = _repo.Specials();
            return View(specials);
        }

        public IActionResult Merch()
        {
            var merch = _repo.Merch();
            return View(merch);
        }
    }
}
    


