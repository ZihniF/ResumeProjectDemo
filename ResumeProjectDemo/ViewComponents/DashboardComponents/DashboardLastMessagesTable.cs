using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemo.Context;

namespace ResumeProjectDemo.ViewComponents.DashboardComponents
{
    public class DashboardLastMessagesTable :ViewComponent
    {
        private readonly ResumeContext _context;

        public DashboardLastMessagesTable(ResumeContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var values = _context.Messages.OrderByDescending(x => x.MessageId).Take(5).ToList();
            return View(values);
        }
    }
}
