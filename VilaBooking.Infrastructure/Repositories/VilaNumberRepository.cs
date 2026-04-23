using VilaBooking.Application.Common.Interfaces;
using VilaBooking.Domain.Entities;
using VilaBooking.Infrastructure.Data;

namespace VilaBooking.Infrastructure.Repositories
{
    public class VilaNumberRepository(VilaBookingContext context) : BaseRepository<VilaNumber>(context), IVilaNumberRepository
    {
        private readonly VilaBookingContext _context = context;
        public void Update(VilaNumber enity)
        {
            _context.VilaNumbers.Update(enity);
        }
    }
}