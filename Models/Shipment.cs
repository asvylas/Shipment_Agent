using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shipment_Agent.Models
{
  public class Shipment
  {
    public string ShipmentID { get; set; }
    public int ClientID { get; set; }
    public int ClientReference1 { get; set; }
    public int ClientReference2 { get; set; }
    public int ClientReference3 { get; set; }

    public string PickupCountry { get; set; }
    public string PickupCity { get; set; }
    public string PickupAddress { get; set; }
    public string PickupZip { get; set; }
    public string PickupCompany { get; set; }
    public string PickupName { get; set; }
    public string PickupPhone { get; set; }
    public string PickupReference { get; set; }
    public string PickupInstructions { get; set; }

    public string DestinationCountry { get; set; }
    public string DestinationCity { get; set; }
    public string DestinationAddress { get; set; }
    public string DestinationZip { get; set; }
    public string DestinationCompany { get; set; }
    public string DestinationName { get; set; }
    public string DestinationPhone { get; set; }
    public string DestinationReference { get; set; }
    public string DestinationInstructions { get; set; }

    private static ShipmentDBContext _shipmentDBContext;
    public Shipment(ShipmentDBContext shipmentDBContext)
    {
      _shipmentDBContext = shipmentDBContext;
    }

    public static string GenerateID(int ClientID)
    {
      try
      {
        var Client = _shipmentDBContext.ClientAuths
          .Where(a => a.ID == ClientID).Single();
        var CurrentShipmentID = _shipmentDBContext.Shipments
          .Where(a => a.ClientID == ClientID)
          .Max(a => a.ShipmentID) + 1;
        string ShipmentID = "1010001" + Client.ID + CurrentShipmentID;
        return ShipmentID;
      }
      catch (System.Exception ex)
      {
        throw ex;
      }
    }
  }
}