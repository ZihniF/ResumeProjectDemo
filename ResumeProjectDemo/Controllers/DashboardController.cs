using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemo.Context;

namespace ResumeProjectDemo.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ResumeContext _context;

        public DashboardController(ResumeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
