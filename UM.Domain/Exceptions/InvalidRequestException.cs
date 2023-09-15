using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UM.Domain.Exceptions
{
    public class InvalidRequestException : Exception
    {
        public List<string> Errors { get; }

        public InvalidRequestException(List<string> errors)
        {
            Errors = errors;
        }

        public InvalidRequestException(string error)
        {
            Errors = new List<string>() { error };
        }
    }
}
