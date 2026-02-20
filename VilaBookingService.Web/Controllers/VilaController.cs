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
                TempData["success"] = "The villa has been created successfully.";
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Update(int vilaId)
        {
            var vila = await _context.Vilas.FindAsync(vilaId);
            if (vila == null) 
            {
                TempData["error"] = $"The villa by this id:{{{vilaId}}} has not found";
                return RedirectToAction("Error", "Home");
            }
            return View(vila);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Vila obj)
        {
            if (ModelState.IsValid && obj.Id > 0)
            {
                _context.Vilas.Update(obj);
                await _context.SaveChangesAsync();
                TempData["success"] = "The villa has been updated successfully.";
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Delete(int vilaId)
        {
            var vila = await _context.Vilas.FindAsync(vilaId);
            if (vila == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(vila);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Vila obj) 
        {
            var vila = await _context.Vilas.FindAsync(obj.Id);
            if (vila == null)
            {
                return RedirectToAction("Error", "Home");
            }
            _context.Vilas.Remove(vila);
            await _context.SaveChangesAsync();
            TempData["success"] = "The villa has been deleted successfully.";
            return RedirectToAction("Index");
        }

    }
}
