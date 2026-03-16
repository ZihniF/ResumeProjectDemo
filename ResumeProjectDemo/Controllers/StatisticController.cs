using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemo.Context;

namespace ResumeProjectDemo.Controllers
{
    public class StatisticController : Controller
    {
        private readonly ResumeContext _context;

        public StatisticController(ResumeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.v1=_context.Messages.Count();
            ViewBag.v2=_context.Messages.Where(x=>x.IsRead==false).Count();
            ViewBag.v2=_context.Messages.Where(x=>x.IsRead==true).Count();
            ViewBag.v2 = _context.Messages.Where(x => x.MessageId == 1).Select(y => y.NameSurname).FirstOrDefault();
            return View();
        }
    }
}
