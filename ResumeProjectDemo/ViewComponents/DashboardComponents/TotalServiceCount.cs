using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemo.Context;

namespace ResumeProjectDemo.ViewComponents.DashboardComponents
{
    public class TotalServiceCount :ViewComponent
    {
        private readonly ResumeContext _context;

        public TotalServiceCount(ResumeContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var value = _context.Services.Count();
            return View(value);
        }
    }
}
