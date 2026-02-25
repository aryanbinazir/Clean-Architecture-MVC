using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VilaBookingService.Domain.Entities;

namespace VilaBookingService.Application.Common.Interfaces
{
    public interface IVilaNumberRepository : IBaseRepository<VilaNumber>
    {
        void Update(VilaNumber enity);
    }
}
