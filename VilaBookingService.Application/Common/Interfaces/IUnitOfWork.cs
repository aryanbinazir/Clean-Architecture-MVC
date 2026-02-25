using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VilaBookingService.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        public IVilaRepository Vila {get;}
        public IVilaNumberRepository VilaNumber {get;}
        
        void Save();
    }
}
