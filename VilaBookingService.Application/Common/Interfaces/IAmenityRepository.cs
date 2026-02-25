using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using VilaBookingService.Domain.Entities;

namespace VilaBookingService.Application.Common.Interfaces
{
    public interface IAmenityRepository : IBaseRepository<Amenity>
    {
        void Update(Amenity entity);
    }
}

