using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shipment_Agent.Models
{
  public class Shipment
  {
    [Key]
    [MaxLength(256)]
    [Required]
    public string ShipmentID { get; set; }
    [Required]
    public int ClientID { get; set; }
    public int ClientReference1 { get; set; }
    public int ClientReference2 { get; set; }
    public int ClientReference3 { get; set; }
    [MaxLength(40)]
    [Required]
    public string PickupCountry { get; set; }
    [MaxLength(40)]  
    [Required]
    public string PickupCity { get; set; }
    [MaxLength(40)]  
    [Required]
    public string PickupAddress { get; set; }
    [MaxLength(40)]  
    [Required]
    public string PickupZip { get; set; }
    [MaxLength(40)]  
    [Required]
    public string PickupCompany { get; set; }
    [MaxLength(40)]
    [Required]
    public string PickupName { get; set; }
    [MaxLength(40)]  
    public string PickupPhone { get; set; }
    [MaxLength(40)]  
    public string PickupReference { get; set; }
    [MaxLength(40)]  
    public string PickupInstructions { get; set; }
    [MaxLength(40)]
    [Required]
    public string DestinationCountry { get; set; }
    [MaxLength(40)]
    [Required]
    public string DestinationCity { get; set; }
    [MaxLength(40)]
    [Required]  
    public string DestinationAddress { get; set; }
    [MaxLength(40)]
    [Required]  
    public string DestinationZip { get; set; }
    [MaxLength(40)]
    [Required]  
    public string DestinationCompany { get; set; }
    [MaxLength(40)]
    [Required]  
    public string DestinationName { get; set; }
    [MaxLength(40)]  
    public string DestinationPhone { get; set; }
    [MaxLength(40)]  
    public string DestinationReference { get; set; }
    [MaxLength(40)]  
    public string DestinationInstructions { get; set; }

    public static string GenerateID(int ClientID)
    {
      try
      {
        // var Client = _shipmentDBContext.ClientAuths
        //   .Where(a => a.ID == ClientID).Single();
        // using (var context = new )
        // {
        //   var blogs = context.Blogs.ToList();
        // }
        // var CurrentShipmentID = _shipmentDBContext.Shipments
        //   .Where(a => a.ClientID == ClientID)
        //   .OrderByDescending(a => a.ShipmentID)
        //   .FirstOrDefault();
        string ShipmentID = "1010001" + ClientID + "aaaaa";
        return ShipmentID;
      }
      catch (System.Exception ex)
      {
        throw ex;
      }
    }
  }
}