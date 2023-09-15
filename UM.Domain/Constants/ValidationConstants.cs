using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UM.Domain.Constants
{
    public static class ValidationConstants
    {
        public static class User
        {
            public const int MaxNameLength = 50;

            public const int MaxEmailLength = 50;

            public const int MinPasswordLength = 6;

            public const int MaxPasswordLength = 30;
            public const int MinUserNameLength = 5;

        }
    }
}
