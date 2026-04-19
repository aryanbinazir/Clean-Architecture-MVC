using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VilaBookingService.Application.Common.Interfaces;
using VilaBookingService.Domain.Entities;
using VilaBookingService.Web.ViewModels;

namespace VilaBookingService.Web.Controllers
{
    public class AmenityController(IUnitOfWork unitOfWork) : Controller
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public IActionResult Index()
        {
            var amenities = _unitOfWork.Amenity.GetAll(includeProperties: nameof(Vila));
            return View(amenities);
        }

        public IActionResult IndexById(int vilaId)
        {
            if (!_unitOfWork.Vila.Any(v => v.Id == vilaId))
                return RedirectToAction("Error", "Home");

            var amenities = _unitOfWork.Amenity.GetAll(filter: v => v.VilaId == vilaId, includeProperties: nameof(Vila));
            return View(amenities);
        }

        public IActionResult Create()
        {
            var amenityVM = new AmenityVM()
            {
                VilaList = _unitOfWork.Vila.GetAll()
                   .Select(v => new SelectListItem
                   {
                       Text = v.Name,
                       Value = v.Id.ToString()
                   })
                   .ToList()
            };
            return View(amenityVM);
        }

        [HttpPost]
        public IActionResult Create(AmenityVM obj)
        {
            bool amenityExist = _unitOfWork.Amenity.Any(v => v.Id == obj.Amenity!.Id);

            if (ModelState.IsValid && !amenityExist)
            {
                _unitOfWork.Amenity.Add(obj.Amenity);
                _unitOfWork.Save();
                TempData["success"] = "The amenity has been created successfully.";
                return RedirectToAction(nameof(Index));
            }

            if (amenityExist)
            {
                TempData["error"] = $"This amenity:{obj.Amenity.Id} is already exist";
                obj.VilaList = _unitOfWork.Vila.GetAll()
                   .Select(v => new SelectListItem
                   {
                       Text = v.Name,
                       Value = v.Id.ToString()
                   })
                   .ToList();
            };
            return View(obj);
        }

        public IActionResult Update(int amenityID)
        {
            var amenityVM = new AmenityVM()
            {
                VilaList = _unitOfWork.Vila.GetAll()
                   .Select(v => new SelectListItem
                   {
                       Text = v.Name,
                       Value = v.Id.ToString()
                   })
                   .ToList(),
                Amenity = _unitOfWork.Amenity.Get(v => v.Id == amenityID)
            };

            if (amenityVM.Amenity == null)
            {
                TempData["error"] = $"The amenity:{amenityID} has not found";
                return RedirectToAction("Error", "Home");
            }
            return View(amenityVM);
        }

        [HttpPost]
        public IActionResult Update(AmenityVM obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Amenity.Update(obj.Amenity);
                _unitOfWork.Save();
                TempData["success"] = "The amenity has been updated successfully.";
                return RedirectToAction(nameof(Index));
            }

            obj.VilaList = _unitOfWork.Vila.GetAll()
                   .Select(v => new SelectListItem
                   {
                       Text = v.Name,
                       Value = v.Id.ToString()
                   })
                   .ToList();

            return View(obj);
        }

        public ActionResult Delete(int amenityId)
        {
            var vilaNumber = _unitOfWork.Amenity.Get(v => v.Id == amenityId, includeProperties: "Vila");

            if (vilaNumber == null)
            {
                TempData["error"] = $"The amenity:{amenityId} has not found";
                return RedirectToAction("Error", "Home");
            }
            return View(vilaNumber);
        }


        [HttpPost]
        public IActionResult Delete(Amenity obj)
        {
            var amenity = _unitOfWork.Amenity.Get(v => v.Id == obj.Id);
            if (amenity is null)
            {
                return RedirectToAction("Error", "Home");
            }
            _unitOfWork.Amenity.Remove(amenity);
            _unitOfWork.Save();
            TempData["success"] = "The amenity has been deleted successfully.";
            return RedirectToAction(nameof(Index));
        }

    }
}
