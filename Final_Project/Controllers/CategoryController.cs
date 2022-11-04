using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Final_Project.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepo _repo;

        public CategoryController(ICategoryRepo repo)
        {
            _repo = repo;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var products = _repo.GetCategories();
            return View(products);
        }
            public IActionResult ViewCategory(int id)
        {
            var category = _repo.GetCategory(id);
            return View(category);
        }

        public IActionResult InsertCategory(Category categoryToInsert)
        {
            var categories = _repo.GetCategories();
            _repo.InsertCategory(categoryToInsert);
            return View(categories);
        }

        public IActionResult InsertProductToDatabase(Category categoryToInsert)
        {
            _repo.InsertCategory(categoryToInsert);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateCategory(int id)
        {
            Category cat = _repo.GetCategory(id);
            if (cat == null)
            {
                return View("CategoryNotFound");
            }
            return View(cat);
        }

        public IActionResult UpdateCategoryToDatabase(Category category)
        {
            _repo.UpdateCategory(category);

            return RedirectToAction("ViewCategory", new { id = category.CategoryID });
        }

        public IActionResult DeleteProduct(Category category)
        {
            _repo.DeleteCategory(category);
            return RedirectToAction("Index");
        }
    }
}
    



