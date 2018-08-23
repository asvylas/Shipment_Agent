using System;
using System.Threading.Tasks;
using Shipment_Agent.Models;

namespace Shipment_Agent.Services.Shipment
{
  public class ShipmentMaster
  {
    public static async Task<Models.Shipment> CreateShipment(Models.Shipment data, ShipmentDBContext _contex)
    {
      data.ShipmentID = ShipmentMaster.GenerateShipmentID(data.ClientID);
      await _contex.Shipments.AddAsync(data);
      await _contex.SaveChangesAsync();
      return data;
    }

    public static string GenerateShipmentID(int clientID)
    {
      string shipmentID = "166061" + clientID.ToString();
      return shipmentID;
    }
  }
}