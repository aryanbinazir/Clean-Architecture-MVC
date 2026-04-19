using VilaBookingService.Domain.Entities;

namespace VilaBookingService.Application.Common.Interfaces
{
    public interface IVilaNumberRepository : IBaseRepository<VilaNumber>
    {
        void Update(VilaNumber enity);
    }
}
