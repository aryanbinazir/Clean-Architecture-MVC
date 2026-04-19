using VilaBookingService.Domain.Entities;

namespace VilaBookingService.Application.Common.Interfaces
{
    public interface IAmenityRepository : IBaseRepository<Amenity>
    {
        void Update(Amenity entity);
    }
}

