using Microsoft.EntityFrameworkCore;
using VilaBookingService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VilaBookingService.Infrastructure.Data
{
    public class VilaBookingContext(DbContextOptions<VilaBookingContext> options) : DbContext(options)
    {
        public DbSet<Vila> Vilas { get; set; }
    }
}
