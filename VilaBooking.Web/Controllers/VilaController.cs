using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using VilaBooking.Application.Common.Interfaces;
using VilaBooking.Domain.Entities;
using VilaBooking.Infrastructure.Data;

namespace VilaBooking.Web.Controllers
{
    public class VilaController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment) : Controller
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;

        public IActionResult Index()
        {
            var vilas = _unitOfWork.Vila.GetAll(includeProperties: $"{nameof(Vila.VilaNumbers)},{nameof(Vila.Amenities)}");
            return View(vilas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Vila obj)
        {
            CheckImageExtension(obj);

            if (ModelState.IsValid)
            {
                if (obj.Image is not null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(obj.Image?.FileName);
                    string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, @"images\VilaImage");

                    using var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create);
                    obj.Image?.CopyTo(fileStream);

                    obj.ImageUrl = @"\images\VilaImage\" + fileName;
                }
                else
                {
                    obj.ImageUrl = "https://placehold.co/600x400";
                }

                obj.CreatedAt = DateTime.Now;
                _unitOfWork.Vila.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "The villa has been created successfully.";
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        public IActionResult Update(int vilaId)
        {
            var vila = _unitOfWork.Vila.Get(v => v.Id == vilaId);
            if (vila == null) 
            {
                TempData["error"] = $"The vilaId:{vilaId} has not found";
                return RedirectToAction("Error", "Home");
            }

            if (vila.CreatedAt.HasValue)
            {
                HttpContext.Session.SetString(
                    "VilaCreatedAt",
                    vila.CreatedAt.Value.ToString("o")
                );
            }

            return View(vila);
        }

        [HttpPost]
        public IActionResult Update(Vila obj)
        {
            CheckImageExtension(obj);

            if (ModelState.IsValid && obj.Id > 0)
            {
                if (obj.Image != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(obj.Image.FileName);
                    string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, @"images\VilaImage");

                    if (!string.IsNullOrEmpty(obj.ImageUrl))
                    {
                        var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, obj.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create);
                    obj.Image.CopyTo(fileStream);

                    obj.ImageUrl = @"\images\VilaImage\" + fileName;
                }

                var dateString = HttpContext.Session.GetString("VilaCreatedAt");

                if (dateString != null)
                    obj.CreatedAt = DateTime.Parse(dateString);
 
                obj.UpdatedAt = DateTime.Now;
                _unitOfWork.Vila.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "The villa has been updated successfully.";
                return RedirectToAction(nameof(Index));
            }

            return View(obj);
        }

        public IActionResult Delete(int vilaId)
        {
            var vila = _unitOfWork.Vila.Get(v => v.Id == vilaId);
            if (vila == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(vila);
        }

        [HttpPost]
        public IActionResult Delete(Vila obj)
        {
            var vila = _unitOfWork.Vila.Get(v => v.Id == obj.Id);
            if (vila == null)
            {
                TempData["error"] = $"This vilaID:{obj.Id} has not found";
                return RedirectToAction("Error", "Home");
            }
            if (!string.IsNullOrEmpty(vila.ImageUrl))
            {
                var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, vila.ImageUrl.TrimStart('\\'));
                
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
            }
            _unitOfWork.Vila.Remove(vila);
            _unitOfWork.Save();
            TempData["success"] = "The villa has been deleted successfully.";
            return RedirectToAction(nameof(Index));
        }

        private void CheckImageExtension(Vila obj) 
        {
            string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };
            string? imageExtension = Path.GetExtension(obj.Image?.FileName)?.ToLower();
            if (imageExtension is not null && !allowedExtensions.Contains(imageExtension))
            {
                ModelState.AddModelError(nameof(Vila.ImageUrl), "Only .jpg, .jpeg, .png files are allowed.");   
            }
        }

    }
}
