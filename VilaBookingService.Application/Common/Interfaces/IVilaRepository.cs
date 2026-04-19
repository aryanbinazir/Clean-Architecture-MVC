using VilaBookingService.Domain.Entities;

namespace VilaBookingService.Application.Common.Interfaces
{
    public interface IVilaRepository : IBaseRepository<Vila>
    {
        void Update(Vila entity);
    }
}

