using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemo.Context;
using ResumeProjectDemo.Entities;

namespace ResumeProjectDemo.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ResumeContext _context;
        public CategoryController(ResumeContext context)
        {
            _context = context;
        }

        public IActionResult CategoryList()
        {
            var values = _context.Categories.ToList();
            return View(values);
        }

        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                // ModelState neden geçersiz bunu görmek için
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return Content("ModelState geçersiz: " + string.Join(", ", errors));
            }

            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("PortfolioList", "Portfolio");
        }

        public IActionResult UpdateCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null) return NotFound();
            return View(category);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Update(category);
                _context.SaveChanges();
                return RedirectToAction("PortfolioList", "Portfolio");
            }
            return View(category);
        }

        public IActionResult DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
            return RedirectToAction("PortfolioList", "Portfolio");
        }
        [HttpPost]
        public JsonResult AddCategory(string categoryName)
        {
            if (string.IsNullOrWhiteSpace(categoryName))
                return Json(new { success = false, message = "Kategori adı boş olamaz." });

            var existing = _context.Categories.FirstOrDefault(c => c.CategoryName == categoryName);
            if (existing != null)
                return Json(new { success = false, message = "Bu kategori zaten mevcut." });

            var newCategory = new Category
            {
                CategoryName = categoryName
            };

            _context.Categories.Add(newCategory);
            _context.SaveChanges();

            return Json(new { success = true, id = newCategory.CategoryId, name = newCategory.CategoryName });
        }
    }
}