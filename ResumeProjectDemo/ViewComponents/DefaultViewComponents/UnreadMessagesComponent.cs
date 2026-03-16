using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemo.Context;

namespace ResumeProjectDemo.ViewComponents.AdminViewComponents
{
    public class UnreadMessagesComponent : ViewComponent
    {
        private readonly ResumeContext _context;

        public UnreadMessagesComponent(ResumeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Messages
                .Where(x => x.IsRead == false)
                .OrderByDescending(x => x.MessageId)
                .Take(5)
                .ToList();

            return View(values);
        }
    }
}