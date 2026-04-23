using VilaBooking.Domain.Entities;

namespace VilaBooking.Application.Common.Interfaces
{
    public interface IVilaNumberRepository : IBaseRepository<VilaNumber>
    {
        void Update(VilaNumber enity);
    }
}
