using System;
using System.IdentityModel.Tokens.Jwt;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using Shipment_Agent.Services;
using Microsoft.IdentityModel.Tokens;
using Shipment_Agent.Classes;

namespace Shipment_Agent.Services.Auth
{
  public class TokenMaster
  {
    private static string Secret;
    public static void SetSecret(string secureSecret)
    {
      TokenMaster.Secret = secureSecret;
    }

    public static string GenerateToken(string clientName)
    {
      byte[] Key = Convert.FromBase64String(TokenMaster.Secret);
      var SecurityKey = new SymmetricSecurityKey(Key);
      SecurityTokenDescriptor Descriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new[]
        {
          new Claim(ClaimTypes.Name, clientName)
        }),
        Expires = DateTime.Now.AddHours(2),
        SigningCredentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256Signature)
      };
      JwtSecurityTokenHandler Handler = new JwtSecurityTokenHandler();
      JwtSecurityToken Token = Handler.CreateJwtSecurityToken(Descriptor);
      return Handler.WriteToken(Token);
    }

    public static ClaimsPrincipal ValidateToken(UserToken userToken)
    {
      try
      {
          JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
          JwtSecurityToken jwtToken = (JwtSecurityToken)tokenHandler.ReadJwtToken(userToken.Token);
          if (jwtToken == null)
          {
            return null;
          }
          byte[] key = Convert.FromBase64String(TokenMaster.Secret);
          TokenValidationParameters parameters = new TokenValidationParameters()
          {
            RequireExpirationTime = true,
            ValidateIssuer = false,
            ValidateAudience = false,
            IssuerSigningKey = new SymmetricSecurityKey(key)
          };
          SecurityToken securityToken;
          ClaimsPrincipal principal = tokenHandler.ValidateToken(userToken.Token, parameters, out securityToken);
          return principal;
      }
      catch (System.Exception)
      {
        return null;
      }
    }
  }
}