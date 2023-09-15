using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UM.Domain.Primitives
{
    public interface IDeletable
    {
        public DateTimeOffset? Deleted { get; set; }
    }
}
