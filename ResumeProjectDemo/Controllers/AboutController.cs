using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemo.Context;
using ResumeProjectDemo.Dtos;
using ResumeProjectDemo.Entities;

namespace ResumeProjectDemo.Controllers
{
    public class AboutController : Controller
    {
        private readonly ResumeContext _context;

        public AboutController(ResumeContext context)
        {
            _context = context;
        }

        public IActionResult AboutList()
        {
            var about = _context.Abouts.FirstOrDefault();
            var educations = _context.Educations.ToList();
            var experiences = _context.Experiences.ToList();

            var value = new AboutModel
            {
                Educations = educations,
                About = about,
                Experiences = experiences
            };

            return View(value);
        }

        // -------------------------
        // CREATE GET (Kısıtlama Ekledik)
        // -------------------------
        [HttpGet]
        public IActionResult CreateAbout()
        {
            // Eğer About zaten varsa Create sayfasına gidilmesin
            if (_context.Abouts.Any())
            {
                return RedirectToAction("AboutList");
            }

            return View();
        }

        // -------------------------
        // CREATE POST (Kısıtlama Ekledik)
        // -------------------------
        [HttpPost]
        public IActionResult CreateAbout(About about)
        {
            // Eğer About zaten varsa ekleme yapılmasın
            if (_context.Abouts.Any())
            {
                ModelState.AddModelError("", "Hakkımda bilgisi zaten mevcut. Yeni kayıt ekleyemezsiniz.");
                return View(about);
            }

            _context.Add(about);
            _context.SaveChanges();

            return RedirectToAction("AboutList");
        }

        public IActionResult DeleteAbout(int id)
        {
            var value = _context.Abouts.Find(id);
            _context.Abouts.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("AboutList");
        }

        [HttpPost]
        public IActionResult UpdateAbout(About about)
        {
            _context.Abouts.Update(about);
            _context.SaveChanges();
            return RedirectToAction("AboutList");
        }

        public IActionResult UpdateAbout(int id)
        {
            var value = _context.Abouts.Find(id);
            return View(value);
        }
    }
}