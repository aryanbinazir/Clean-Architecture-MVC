using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using VilaBookingService.Application.Common.Interfaces;
using VilaBookingService.Domain.Entities;
using VilaBookingService.Infrastructure.Data;
using VilaBookingService.Web.ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace VilaBookingService.Web.Controllers
{
    public class VilaNumberController(IUnitOfWork unitOfWork) : Controller
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public  IActionResult Index()
        {
            var vilaNumbers = _unitOfWork.VilaNumber.GetAll(includeProperties: nameof(Vila));
            return View(vilaNumbers);
        }

        public  IActionResult IndexById(int vilaId)
        {
            if (!_unitOfWork.Vila.Any(v => v.Id == vilaId))
                return RedirectToAction("Error", "Home");

            var vilaNumbers = _unitOfWork.VilaNumber.GetAll(filter:v => v.VilaId == vilaId, includeProperties: nameof(Vila));
            return View(vilaNumbers);
        }

        public IActionResult Create()
        { 
            var vilaNumberVM = new VilaNumberVM()
            {
                VilaList = _unitOfWork.Vila.GetAll()
                   .Select(v => new SelectListItem
                   {
                       Text = v.Name,
                       Value = v.Id.ToString()
                   })
                   .ToList()
            };
            return View(vilaNumberVM);
        }

        [HttpPost]
        public IActionResult Create(VilaNumberVM obj)
        {
            bool vilaNumberExist = _unitOfWork.VilaNumber.Any(v => v.Vila_Number == obj.VilaNumber!.Vila_Number);

            if (ModelState.IsValid && !vilaNumberExist)
            {
                _unitOfWork.VilaNumber.Add(obj.VilaNumber);
                _unitOfWork.Save();
                TempData["success"] = "The vila number has been created successfully.";
                return RedirectToAction(nameof(Index));
            }

            if (vilaNumberExist)
            {
                TempData["error"] = $"This vila number:{obj.VilaNumber.Vila_Number} is already exist";
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

        public IActionResult Update(int vilaNumberID)
        {
            var vilaNumberVM = new VilaNumberVM()
            {
                VilaList = _unitOfWork.Vila.GetAll()
                   .Select(v => new SelectListItem
                   {
                       Text = v.Name,
                       Value = v.Id.ToString()
                   })
                   .ToList(),
                VilaNumber = _unitOfWork.VilaNumber.Get(v => v.Vila_Number == vilaNumberID)
            };

            if (vilaNumberVM.VilaNumber == null)
            {
                TempData["error"] = $"The vila number:{vilaNumberID} has not found";
                return RedirectToAction("Error", "Home");
            }
            return View(vilaNumberVM);
        }

        [HttpPost]
        public IActionResult Update(VilaNumberVM obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.VilaNumber.Update(obj.VilaNumber);
                _unitOfWork.Save();
                TempData["success"] = "The vila number has been updated successfully.";
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

        public  ActionResult Delete(int vilaNumberID)
        {
            var vilaNumber = _unitOfWork.VilaNumber.Get(v => v.Vila_Number == vilaNumberID, includeProperties: "Vila");

            if (vilaNumber == null)
            {
                TempData["error"] = $"The vila number:{vilaNumberID} has not found";
                return RedirectToAction("Error", "Home");
            }
            return View(vilaNumber);
        }


        [HttpPost]
        public IActionResult Delete(VilaNumber obj) 
        {
            var vilaNumber = _unitOfWork.VilaNumber.Get(v => v.Vila_Number == obj.Vila_Number);
            if (vilaNumber is null)
            {
                return RedirectToAction("Error", "Home");
            }
            _unitOfWork.VilaNumber.Remove(vilaNumber);
            _unitOfWork.Save();
            TempData["success"] = "The vila number has been deleted successfully.";
            return RedirectToAction(nameof(Index));
        }

    }
}
