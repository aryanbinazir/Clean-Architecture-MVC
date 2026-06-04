using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VilaBooking.Application.Common.Interfaces;
using VilaBooking.Web.Models;
using VilaBooking.Web.ViewModels;

namespace VilaBooking.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;   
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new()
            {
                VilaList = _unitOfWork.Vila.GetAll(includeProperties: "Amenities, VilaNumbers"),
                CheckInDate = DateOnly.FromDateTime(DateTime.Now),
                Nights = 1
            }; 
            return View(homeVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Error() 
        {
            return View();
        }
    }
}
