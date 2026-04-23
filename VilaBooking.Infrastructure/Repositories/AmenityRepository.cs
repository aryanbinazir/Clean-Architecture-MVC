using VilaBooking.Application.Common.Interfaces;
using VilaBooking.Domain.Entities;
using VilaBooking.Infrastructure.Data;

namespace VilaBooking.Infrastructure.Repositories
{
    public class AmenityRepository(VilaBookingContext context) : BaseRepository<Amenity>(context), IAmenityRepository
    {
        private readonly VilaBookingContext _context = context;
        public void Update(Amenity enity)
        {
            _context.Amenities.Update(enity);
        }
    }
}
