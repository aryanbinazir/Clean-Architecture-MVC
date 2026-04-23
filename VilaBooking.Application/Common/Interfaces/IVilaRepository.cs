using VilaBooking.Domain.Entities;

namespace VilaBooking.Application.Common.Interfaces
{
    public interface IVilaRepository : IBaseRepository<Vila>
    {
        void Update(Vila entity);
    }
}

