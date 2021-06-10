using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace FilmsListBackEnd.Helpers
{
    public class JwtGenerator : IJwtGenerator
    {
        public JwtHeader jwtHeader;
        public IList<Claim> jwtClaims;
        public DateTime jwtDate;
        public int tokenLifetimeInSeconds;

        public JwtGenerator(IConfiguration _config)

        {
            //var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            //var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var credentials = new SigningCredentials(
                key: new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"])),
                algorithm: SecurityAlgorithms.HmacSha256);


            jwtHeader = new JwtHeader(credentials);
            jwtClaims = new List<Claim>();
            jwtDate = DateTime.UtcNow;
            tokenLifetimeInSeconds = int.Parse(_config["Jwt:LifeTimeInSeconds"]);
        }

        public JwtGenerator AddClaim(Claim claim)
        {
            jwtClaims.Add(claim);
            return this;
        }
        public long GetTokenExpirationInUnixTime => new DateTimeOffset(
            jwtDate.AddSeconds(tokenLifetimeInSeconds))
            .ToUnixTimeMilliseconds();


        public string GetToken()
        {
            var jwt = new JwtSecurityToken(
                jwtHeader, new JwtPayload(
                    audience: "identityapp",
                    issuer: "identityapp",
                    notBefore: jwtDate,
                    expires: jwtDate.AddSeconds(tokenLifetimeInSeconds),
                    claims: jwtClaims
                    ));
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }  
    }
}