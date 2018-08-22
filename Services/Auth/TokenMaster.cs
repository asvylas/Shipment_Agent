using System;
using System.IdentityModel.Tokens.Jwt;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using Shipment_Agent.Services;
using Microsoft.IdentityModel.Tokens;

namespace Shipment_Agent.Services.Auth
{
  public class TokenMaster
  {
    private static string Secret;
    public static void SetSecret(String SecureSecret)
    {
      string Secret = SecureSecret;
    }
    public static string GenerateToken(string ClientName, string ClientID)
    {
      byte[] Key = Convert.FromBase64String(Secret + ClientID);
      var SecurityKey = new SymmetricSecurityKey(Key);
      SecurityTokenDescriptor Descriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new[]
        {
          new Claim(ClaimTypes.Name, ClientName)
        }),
        Expires = DateTime.Now.AddHours(2),
        SigningCredentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256Signature)
      };
      JwtSecurityTokenHandler Handler = new JwtSecurityTokenHandler();
      JwtSecurityToken Token = Handler.CreateJwtSecurityToken(Descriptor);
      return Handler.WriteToken(Token);
    }
  }
}