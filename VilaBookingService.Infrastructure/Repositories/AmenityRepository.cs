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
    public class VilaNumberRepository(VilaBookingContext context) : BaseRepository<VilaNumber>(context), IVilaNumberRepository
    {
        private readonly VilaBookingContext _context = context;
        public void Update(VilaNumber enity)
        {
            _context.Update(enity);
        }
    }
}
