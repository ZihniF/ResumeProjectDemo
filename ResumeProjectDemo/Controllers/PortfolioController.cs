using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ResumeProjectDemo.Context;
using ResumeProjectDemo.Entities;
using System.Linq;

namespace ResumeProjectDemo.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly ResumeContext _context;

        public PortfolioController(ResumeContext context)
        {
            _context = context;
        }

        public IActionResult PortfolioList()
        {
            // Portfolioları çek
            var portfolios = _context.Portfolios.Include(x => x.Category).ToList();

            // Kategorileri çek
            var categories = _context.Categories.ToList();

            // ViewModel kullanmadan ViewBag ile gönderebiliriz
            ViewBag.Categories = categories;

            return View(portfolios);
        }
        [HttpGet]
        public IActionResult CreatePortfolio()
        {
            ViewBag.categories = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        public IActionResult CreatePortfolio(Portfolio portfolio)
        {
            if (ModelState.IsValid)
            {
                _context.Portfolios.Add(portfolio);
                _context.SaveChanges();
                return RedirectToAction("PortfolioList");
            }

            ViewBag.categories = new SelectList(_context.Categories.ToList(), "CategoryId", "CategoryName", portfolio.CategoryId);
            return View(portfolio);
        }
        public IActionResult DeletePortfolio(int id)
        {
            var value = _context.Portfolios.Find(id);
            _context.Portfolios.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("PortfolioList");
        }

        [HttpGet]
        public IActionResult UpdatePortfolio(int id)
        {
            ViewBag.categories = new SelectList(_context.Categories.ToList(), "CategoryId", "CategoryName");
            var value = _context.Portfolios.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdatePortfolio(Portfolio portfolio)
        {
            _context.Portfolios.Update(portfolio);
            _context.SaveChanges();
            return RedirectToAction("PortfolioList");
        }

    }
}