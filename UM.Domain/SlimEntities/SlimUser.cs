using UM.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UM.Domain.SlimEntities
{
    public class SlimUser
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public List<string> Roles { get; set; }
        public Guid[] RoleIds { get; set; }
        public Guid HotelId { get; set; }
        public bool IsLocked { get; set; }
    }
}
