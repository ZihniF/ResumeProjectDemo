using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemo.Context;
using ResumeProjectDemo.Entities;
using System;

namespace ResumeProjectDemo.Controllers
{
    public class MessageController : Controller
    {
        private readonly ResumeContext _context;

        public MessageController(ResumeContext context)
        {
            _context = context;
        }
        public IActionResult MessageList()
        {
            var values = _context.Messages.ToList();
            return View(values);
        }
        public IActionResult MessageDetails(int id)
        {
            var message = _context.Messages.Find(id);
            if (message == null) return NotFound();

            if (!message.IsRead)
            {
                message.IsRead = true;
                _context.SaveChanges();
            }

            return View(message); // @model Message
        }
   
        public IActionResult DeleteMessage(int id)
        {
            var value = _context.Messages.Find(id);
            if (value != null)
            {
                _context.Messages.Remove(value);
                _context.SaveChanges();
            }
            return RedirectToAction("MessageList");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SendMessage([FromForm] Message model)
        {
            if (ModelState.IsValid)
            {
                model.SendDate = DateTime.Now;
                model.IsRead = false;

                _context.Messages.Add(model);
                _context.SaveChanges();

                return Ok(); // JS ile ok yanıtı alınacak
            }
            return BadRequest();
        }
    }
}