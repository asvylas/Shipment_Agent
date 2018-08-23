using System.ComponentModel.DataAnnotations;

namespace Shipment_Agent.Models
{
  public class Status
  {
    public string ShipmentID {get;set;}
    public int StatusCode {get;set;}
    public string Locations {get;set;}
  }
}