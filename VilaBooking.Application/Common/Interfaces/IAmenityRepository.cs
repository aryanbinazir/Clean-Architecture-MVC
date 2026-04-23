using VilaBooking.Domain.Entities;

namespace VilaBooking.Application.Common.Interfaces
{
    public interface IAmenityRepository : IBaseRepository<Amenity>
    {
        void Update(Amenity entity);
    }
}

