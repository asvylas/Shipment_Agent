using System;
using System.Linq;
using System.Security.Cryptography;
using Shipment_Agent.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Shipment_Agent.Classes;

namespace Shipment_Agent.Services.Auth
{
  public class AuthAndReg
  {
    public static async Task<bool> AuthenticateClient(UserLogin data, ShipmentDBContext _context)
    {
      try
      {
        var Client = await _context.ClientAuths.Where(a => a.NAME == data.Name).FirstAsync();
        var HashValidity = AuthAndReg.CompareHash(data.Password, Client);
        if (!HashValidity)
        {
          throw new Exception("Invalid password.");
        }
        else
        {
          return HashValidity;
        }

      }
      catch (System.Exception)
      {
        throw;
      }
    }

    public static async Task<bool> DeleteUser(UserLogin data, ShipmentDBContext _context)
    {
      try
      {
        bool HashValidity = await AuthenticateClient(data, _context);
        if (HashValidity)
        {
          var Client = await _context.ClientAuths.Where(a => a.NAME == data.Name).FirstAsync();
          _context.Remove(Client);
          await _context.SaveChangesAsync();
        }
        return HashValidity;
      }
      catch (System.Exception)
      {
        throw;
      }
    }

    public static async Task<ClientAuth> RegisterClient(UserLogin data, ShipmentDBContext _context)
    {
      bool checkUnique;
      Models.ClientAuth client;

      checkUnique = _context.ClientAuths
        .Where(a => a.NAME == data.Name)
        .Count() > 0;
      if (checkUnique)
      {
        throw new Exception("Client name must be unique.");
      }
      else
      {
        try
        {
          (string hash, string salt) = GenerateSaltAndHash(data.Password);
          client = new Models.ClientAuth()
          {
            ID = GenerateRN(),
            SALT = salt,
            HASH = hash,
            NAME = data.Name
          };
          _context.ClientAuths.Add(client);
          await _context.SaveChangesAsync();
          return (client);
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
      byte[] salt;
      string hash;

      salt = new byte[128 / 8];
      using (var rng = RandomNumberGenerator.Create())
      {
        rng.GetBytes(salt);
      }
      hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
       password: Password,
       salt: salt,
       prf: KeyDerivationPrf.HMACSHA1,
       iterationCount: 10000,
       numBytesRequested: 256 / 8));
      return (hash, Convert.ToBase64String(salt));
    }

    static int GenerateRN()
    {
      /* TODO -> Generate specific client IDs.?? */
      Random rnd = new Random();
      int ClientID = rnd.Next(100000, 999999);
      return ClientID;
    }

    public static bool CompareHash(string Password, ClientAuth Client)
    {
      string hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
        password: Password,
        salt: Convert.FromBase64String(Client.SALT),
        prf: KeyDerivationPrf.HMACSHA1,
        iterationCount: 10000,
        numBytesRequested: 256 / 8));
      return hash == Client.HASH;
    }
  }
}