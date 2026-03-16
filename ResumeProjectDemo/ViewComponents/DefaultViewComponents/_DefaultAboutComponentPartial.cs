using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemo.Context;
using ResumeProjectDemo.Dtos;
using System.Linq;

namespace ResumeProjectDemo.ViewComponents.DefaultViewComponents
{
    public class _DefaultAboutComponentPartial : ViewComponent
    {
        private readonly ResumeContext _context;

        public _DefaultAboutComponentPartial(ResumeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var about = _context.Abouts.FirstOrDefault(); // tek kayıt
            var educations = _context.Educations.ToList(); // liste
            var experiences = _context.Experiences.Take(2).ToList();


            var value = new AboutModel
            {
                Educations = educations,
                About = about,
                Experiences = experiences
            };

            return View(value);
        }
    }
}
