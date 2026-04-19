using VilaBookingService.Application.Common.Interfaces;
using VilaBookingService.Infrastructure.Data;

namespace VilaBookingService.Infrastructure.Repositories
{
    public class UnitOfWork(VilaBookingContext context) : IUnitOfWork
    {
        private readonly VilaBookingContext _context = context;
        public IVilaRepository Vila { get; private set; } = new VilaRepository(context);
        public IVilaNumberRepository VilaNumber { get; private set; } = new VilaNumberRepository(context);
        public IAmenityRepository Amenity { get; private set; } = new AmenityRepository(context);
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
