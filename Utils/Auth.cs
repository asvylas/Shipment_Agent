using System;
using System.Linq;
using System.Security.Cryptography;
using Shipment_Agent.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Shipment_Agent.Utils
{
  public class Auth
  {
    public string Name { get; set; }
    public string Password { get; set; }

    
  }

  public class Reg
  {
    public static async Task<ClientAuth> AuthenticateClient(Auth data, ShipmentDBContext _context)
    {
      
      var DBHash = await _context.ClientAuths.Where(a => a.NAME == data.Name).FirstAsync();
      var AuthHash = Reg.CompareHash(data.Password, DBHash.SALT);
      ClientAuth Client = new ClientAuth()
      {
        HASH = AuthHash,
        SALT = DBHash.HASH
      };
      return Client;
    }

    public static async Task<ClientAuth> RegisterClient(Auth data, ShipmentDBContext _context)
    {

      bool CheckUnique = _context.ClientAuths.Where(a => a.NAME == data.Name).Count() > 0;
      if (CheckUnique)
      {
        throw new Exception("Client name must be unique");
      }
      else
      {
        try
        {
          _context.ClientAuths.Find(data.Name);
          (string hash, string salt) = GenerateSaltAndHash(data.Password);
          var Client = new Models.ClientAuth()
          {
            ID = GenerateRN(),
            SALT = salt,
            HASH = hash,
            NAME = data.Name
          };
          _context.ClientAuths.Add(Client);
          await _context.SaveChangesAsync();
          return (Client);
        }
        catch (System.Exception ex)
        {
          throw ex;
        }
      }
    }

    public static (string, string) GenerateSaltAndHash(string Password)
    {
      //var RNG = RandomNumberGenerator.Create();
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
      return (hash, Convert.ToBase64String(salt));
    }
    static int GenerateRN()
    {
      Random rnd = new Random();
      int ClientID = rnd.Next(100000, 999999);
      return ClientID;
    }
    public static string CompareHash(string Password, string Salt)
    {
      string hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
        password:Password,
        salt:Convert.FromBase64String(Salt),
        prf:KeyDerivationPrf.HMACSHA1,
        iterationCount:10000,
        numBytesRequested:256 / 8));
      return hash;
    }
  }
}