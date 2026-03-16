using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemo.Context;

namespace ResumeProjectDemo.ViewComponents.DefaultViewComponents
{
    public class _DefaultCategoryComponentPartial : ViewComponent
    {
        private readonly ResumeContext _context;

        public _DefaultCategoryComponentPartial(ResumeContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var values = _context.Categories.ToList();
            return View(values);
        }
    }
}
