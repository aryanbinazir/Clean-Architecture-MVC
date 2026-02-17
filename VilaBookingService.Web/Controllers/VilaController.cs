using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VilaBookingService.Domain.Entities;
using VilaBookingService.Infrastructure.Data;

namespace VilaBookingService.Web.Controllers
{
    public class VilaController(VilaBookingContext context) : Controller
    {
        private readonly VilaBookingContext _context = context;

        public async Task<IActionResult> Index()
        {
            var vilas = await _context.Vilas.ToListAsync();
            return View(vilas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Vila obj)
        {
            if (obj.Name == obj.Description) 
            {
                ModelState.AddModelError("name", "The description cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                await _context.Vilas.AddAsync(obj);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
