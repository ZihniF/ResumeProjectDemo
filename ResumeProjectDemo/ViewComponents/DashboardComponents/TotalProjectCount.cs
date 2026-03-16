using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemo.Context;

namespace ResumeProjectDemo.ViewComponents.DashboardComponents
{
    public class TotalProjectCount :ViewComponent
    {
        private readonly ResumeContext _context;

        public TotalProjectCount(ResumeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var value = _context.Portfolios.Count();
            return View(value);
        }
    }
}
