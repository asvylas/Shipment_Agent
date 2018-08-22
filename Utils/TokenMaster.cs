using System;
using System.IdentityModel.Tokens.Jwt;

namespace Shipment_Agent.Utils
{
  public class TokenMaster
  {
    private static string Secret;
    public static void SetSecret(String SecureSecret)
    {
      string Secret = SecureSecret;
    }
    public static string GetSecret()
    {
      return Secret;
    }
    public static string GenerateToken(Utils.AuthIncData data)
    {

    }
  }
}