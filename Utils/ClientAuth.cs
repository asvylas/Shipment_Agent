using System;
using System.Linq;
using System.Security.Cryptography;
using Shipment_Agent.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Shipment_Agent.Utils
{
  public class ClientAuth
  {

  }
  public class ClientReg
  {
    private static ShipmentDBContext _shipmentDBContext;
    public ClientReg(ShipmentDBContext shipmentDBContext)
    {
      _shipmentDBContext = shipmentDBContext;
    }

    public string NAME { get; set; }
    public string PASSWORD { get; set; }

    public (string, string) RegisterClient(string Name, string Password)
    {
      try
      {
        var NameCheck = _shipmentDBContext.ClientAuths
          .Where(a => a.NAME == NAME);

        if (NameCheck == null)
        {
          (string hash, string salt) = GenerateSaltAndHash(Password);
          return (hash, salt);
        }
        else
        {
          return (null, null);
        }
      }
      catch (System.Exception ex)
      {
        throw ex;
      }

    }

    static (string, string) GenerateSaltAndHash(string Password)
    {
      var RNG = RandomNumberGenerator.Create();
      byte[] salt = new byte[128 / 8];
      using (var rng = RandomNumberGenerator.Create())
      {
        rng.GetBytes(salt);
      }
      string hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
        password: Password,
        salt: salt,
        prf: KeyDerivationPrf.HMACSHA1,
        iterationCount: 10000,
        numBytesRequested: 256 / 8));
      return (hash, salt.ToString());
    }
  }
}