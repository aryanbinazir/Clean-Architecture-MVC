using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VilaBookingService.Domain.Entities
{
    public class Vila
    {
        public int Id { get; set; }
        [MaxLength(50), DataType(DataType.Text)]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Only letters are allowed.")]
        public required string Name { get; set; }
        public string? Description { get; set; }
        [Display(Name="Price per night"), Range(10, 10_000)]
        public decimal Price { get; set; }
        public int Sqft { get; set; }
        [Range(1, 10)]
        public int Occupancy { get; set; }
        [Display(Name = "Image url")]
        public string? ImageUrl { get; set; }
        public DateTime? CreatedAt{ get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
