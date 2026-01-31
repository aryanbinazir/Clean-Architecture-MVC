using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VilaBookingService.Domain.Entities
{
    // id name description price sqft occupancy imageurl? Createddate? updateddate? 
    public class Vila
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public int Sqft { get; set; }
        public int Occupancy { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? CreatedAt{ get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
