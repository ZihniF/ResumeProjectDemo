using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemo.Context;
using ResumeProjectDemo.Entities;
using System.Linq;

namespace ResumeProjectDemo.Controllers
{
    public class EducationController : Controller
    {
        private readonly ResumeContext _context;

        public EducationController(ResumeContext context)
        {
            _context = context;
        }

        public IActionResult EducationList()
        {
            var educations = _context.Educations.ToList();
            return View(educations);
        }

        [HttpGet]
        public IActionResult CreateEducation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateEducation(Education education)
        {
            if (!ModelState.IsValid)
            {
                return View(education);
            }

            _context.Educations.Add(education);
            _context.SaveChanges();
            return RedirectToAction("AboutList", "About");
        }

        [HttpGet]
        public IActionResult UpdateEducation(int id)
        {
            var education = _context.Educations.Find(id);
            if (education == null)
            {
                return NotFound();
            }

            return View(education);
        }

        [HttpPost]
        public IActionResult UpdateEducation(Education education)
        {
            if (!ModelState.IsValid)
            {
                return View(education);
            }

            _context.Educations.Update(education);
            _context.SaveChanges();
            return RedirectToAction("AboutList", "About");
        }

        // -------------------------
        // DELETE
        // -------------------------
        public IActionResult DeleteEducation(int id)
        {
            var education = _context.Educations.Find(id);
            if (education == null)
            {
                return NotFound();
            }

            _context.Educations.Remove(education);
            _context.SaveChanges();
            return RedirectToAction("AboutList", "About");
        }
    }
}