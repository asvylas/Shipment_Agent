using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shipment_Agent.Models
{
  public class ClientAuth
  {
    [Key]
    [MaxLength(20)]
    [Required]
    public int ID { get; set; }
    [MaxLength(256)]
    [Required]
    public string NAME { get; set; }
    [Required]
    [MaxLength(256)]
    public string HASH { get; set; }
    [Required]
    [MaxLength(256)]
    public string SALT { get; set; }
  }
}