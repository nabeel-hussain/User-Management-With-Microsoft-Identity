using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UM.Domain.Interfaces
{
    public interface IDataSeed
    {
        public Task SecurityDataSeed();
        public Task HotelDataSeed();
    }
}
