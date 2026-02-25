using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using VilaBookingService.Application.Common.Interfaces;
using VilaBookingService.Domain.Entities;
using VilaBookingService.Infrastructure.Data;

namespace VilaBookingService.Infrastructure.Repositories
{
    public class VilaRepository(VilaBookingContext context) : BaseRepository<Vila>(context), IVilaRepository
    {
        private readonly VilaBookingContext _context = context;

        public void Update(Vila entity)
        {
            _context.Update(entity);
        }
    }
}
