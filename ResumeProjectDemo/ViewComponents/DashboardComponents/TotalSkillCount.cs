using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemo.Context;

namespace ResumeProjectDemo.ViewComponents.DashboardComponents
{
    public class TotalSkillCount :ViewComponent
    {
        private readonly ResumeContext _context;

        public TotalSkillCount(ResumeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var value = _context.Skills.Count();
            return View(value);
        }
    }
}
