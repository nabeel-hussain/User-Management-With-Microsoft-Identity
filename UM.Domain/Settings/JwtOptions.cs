using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UM.Domain.Settings;

public class JwtOptions
{

    public string Issuer { get; init; }
    public string Audience { get; init; }
    public string SecretKey { get; init; }
    public double TokenLifeTimeInMinutes { get;init; }

}
