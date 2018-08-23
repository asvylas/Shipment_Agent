using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shipment_Agent.Models;

namespace Shipment_Agent.Services.Shipment
{
  public class ShipmentMaster
  {
    public static async Task<Models.Shipment> CreateShipment(Models.Shipment data, ShipmentDBContext _contex)
    {
      data.ShipmentID = await ShipmentMaster.GenerateShipmentID(data, _contex);
      await _contex.Shipments.AddAsync(data);
      await _contex.SaveChangesAsync();
      return data;
    }

    public static async Task<string> GenerateShipmentID(Models.Shipment data, ShipmentDBContext _contex)
    {
      bool existsCheck;
      string currentID;
      string generatedID;

      try
      {
        existsCheck = (_contex.Shipments
          .Where(a => a.ClientID == data.ClientID)
          .OrderByDescending(a => a.ShipmentID)).Count() > 0;
        if (existsCheck)
        {
          currentID = (await _contex.Shipments
          .Where(a => a.ClientID == data.ClientID)
          .OrderByDescending(a => a.ShipmentID)
          .FirstAsync()).ShipmentID;
          generatedID = (Convert.ToInt64(currentID) + 1).ToString();
        }
        else 
        {
          generatedID = data.ClientID.ToString() + "00000000001";
        }
        return generatedID;
      }
      catch (System.Exception)
      {
        throw;
      }
    }
  }
}