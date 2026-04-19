using VilaBookingService.Application.Common.Interfaces;
using VilaBookingService.Domain.Entities;
using VilaBookingService.Infrastructure.Data;

namespace VilaBookingService.Infrastructure.Repositories
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
