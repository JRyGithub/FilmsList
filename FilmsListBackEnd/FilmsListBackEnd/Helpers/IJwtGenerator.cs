using System;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;

namespace FilmsListBackEnd.Helpers
{
    public interface IJwtGenerator
    {
        JwtGenerator AddClaim(Claim claim);
    }
}
