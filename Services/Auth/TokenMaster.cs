using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

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
      byte[] key;
      SymmetricSecurityKey SecurityKey;
      SecurityTokenDescriptor Descriptor;
      JwtSecurityTokenHandler Handler;
      JwtSecurityToken Token;

      key = Convert.FromBase64String(TokenMaster.Secret);
      SecurityKey = new SymmetricSecurityKey(key);
      Descriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new[]
        {
          new Claim(ClaimTypes.Name, clientName)
        }),
        Expires = DateTime.Now.AddHours(12),
        SigningCredentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256Signature)
      };
      Handler = new JwtSecurityTokenHandler();
      Token = Handler.CreateJwtSecurityToken(Descriptor);
      return Handler.WriteToken(Token);
    }

    public static ClaimsPrincipal GetPrincipal(string token)
    {
      JwtSecurityTokenHandler tokenHandler;
      JwtSecurityToken jwtToken;
      byte[] key;
      TokenValidationParameters parameters;
      SecurityToken securityToken;
      ClaimsPrincipal principal;

      try
      {
        tokenHandler = new JwtSecurityTokenHandler();
        jwtToken = (JwtSecurityToken)tokenHandler.ReadJwtToken(token);
        if (jwtToken == null)
        {
          return null;
        }
        key = Convert.FromBase64String(TokenMaster.Secret);
        parameters = new TokenValidationParameters()
        {
          RequireExpirationTime = true,
          ValidateIssuer = false,
          ValidateAudience = false,
          IssuerSigningKey = new SymmetricSecurityKey(key)
        };
        principal = tokenHandler.ValidateToken(token, parameters, out securityToken);
        return principal;
      }
      catch (System.Exception)
      {
        return null;
      }
    }

    public static string ValidateToken(string token)
    {
      string username = null;
      ClaimsIdentity identity = null;
      Claim usernameClaim = null;

      ClaimsPrincipal principal = GetPrincipal(token);
      if (principal == null)
      {
        throw new Exception("Token expired.");
      }
      try
      {
        identity = (ClaimsIdentity)principal.Identity;
      }
      catch (NullReferenceException)
      {
        return null;
      }
      usernameClaim = identity.FindFirst(ClaimTypes.Name);
      username = usernameClaim.Value;
      return username;
    }
  }
}