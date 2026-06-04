using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using VilaBooking.Domain.Entities;

namespace VilaBooking.Web.ViewModels
{
    public class HomeVM
    {
       public IEnumerable<Vila>? VilaList { get; set; }
        public DateOnly CheckInDate { get; set; }
        public DateOnly? CheckOutDate { get; set; }
        public int Nights { get; set; }
    }
}
