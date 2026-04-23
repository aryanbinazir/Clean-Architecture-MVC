using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using VilaBooking.Domain.Entities;

namespace VilaBooking.Web.ViewModels
{
    public class AmenityVM
    {
        public Amenity? Amenity{ get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? VilaList { get; set; }
    }
}
