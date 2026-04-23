using VilaBooking.Application.Common.Interfaces;
using VilaBooking.Domain.Entities;
using VilaBooking.Infrastructure.Data;

namespace VilaBooking.Infrastructure.Repositories
{
    public class VilaRepository(VilaBookingContext context) : BaseRepository<Vila>(context), IVilaRepository
    {
        private readonly VilaBookingContext _context = context;

        public void Update(Vila entity)
        {
            _context.Vilas.Update(entity);
        }
    }
}
