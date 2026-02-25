using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            _context.Update(enity);
        }
    }
}
