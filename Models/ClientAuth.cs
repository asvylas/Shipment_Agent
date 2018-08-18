using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Shipment_Agent.Models
{
  public class ClientAuth
  {
    public int ID { get; set; }
    public string NAME { get; set; }
    public string HASH { get; set; }
    public string SALT { get; set; }
  }
}