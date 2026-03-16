using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemo.Context;

namespace ResumeProjectDemo.ViewComponents.DashboardComponents
{
    public class NewMessageCount:ViewComponent
    {
        private readonly ResumeContext _context;

        public NewMessageCount(ResumeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            // IsRead false olan (okunmamış) mesajları sayar
            var value = _context.Messages.Count(x => x.IsRead == false);
            return View(value);
        }
    }
}
