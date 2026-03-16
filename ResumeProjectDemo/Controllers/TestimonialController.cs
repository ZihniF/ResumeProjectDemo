using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemo.Context;
using ResumeProjectDemo.Entities;

namespace ResumeProjectDemo.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly ResumeContext _context;

        public TestimonialController(ResumeContext context)
        {
            _context = context;
        }

        public IActionResult TestimonialList()
        {
            var allTestimonials = _context.Testimonials.ToList(); // onaylı / onaysız farketmez
            return View(allTestimonials);
        }
        public IActionResult ChangeStatus(int id, bool status)
        {
            var value = _context.Testimonials.Find(id);
            value.IsConfirm = status;
            _context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }

        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTestimonial(Testimonial testimonial)
        {
            testimonial.IsConfirm = false; // yeni eklenenler onaysız olsun
            _context.Testimonials.Add(testimonial);
            _context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }

        public IActionResult DeleteTestimonial(int id)
        {
            var value = _context.Testimonials.Find(id);
            _context.Testimonials.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }

        [HttpGet]
        public IActionResult UpdateTestimonial(int id)
        {
            var value = _context.Testimonials.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateTestimonial(Testimonial testimonial)
        {
            _context.Testimonials.Update(testimonial);
            _context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }

        // REFERANS ONAYLA
        public IActionResult ConfirmTestimonial(int id)
        {
            var value = _context.Testimonials.Find(id);
            value.IsConfirm = true;
            _context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }

        // REFERANS REDDET
        public IActionResult RejectTestimonial(int id)
        {
            var value = _context.Testimonials.Find(id);
            value.IsConfirm = false;
            _context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }
    }
}