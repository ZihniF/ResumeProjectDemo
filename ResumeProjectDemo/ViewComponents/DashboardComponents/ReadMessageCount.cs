using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemo.Context;

namespace ResumeProjectDemo.ViewComponents.DashboardComponents
{
    public class ReadMessageCount :ViewComponent
    {
        private readonly ResumeContext _context;

        public ReadMessageCount(ResumeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var value = _context.Messages.Count(x => x.IsRead == true);
            return View(value);
        }
    }
}
