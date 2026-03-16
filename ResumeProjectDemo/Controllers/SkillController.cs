using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemo.Context;
using ResumeProjectDemo.Entities;

namespace ResumeProjectDemo.Controllers
{
    public class SkillController : Controller
    {
        private readonly ResumeContext _context;

        public SkillController(ResumeContext context)
        {
            _context = context;
        }

        public IActionResult SkillList()
        {
            var values = _context.Skills.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateSkill()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateSkill(Skill Skill)
        {
            _context.Add(Skill);
            _context.SaveChanges();
            return RedirectToAction("SkillList");
        }

        public IActionResult DeleteSkill(int id)
        {
            var value = _context.Skills.Find(id);
            _context.Skills.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("SkillList");
        }

        public IActionResult UpdateSkill(int id)
        {
            var value = _context.Skills.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateSkill(Skill Skill)
        {
            _context.Skills.Update(Skill);
            _context.SaveChanges();
            return RedirectToAction("SkillList");
        }

    }
}
