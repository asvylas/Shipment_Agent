using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace Shipment_Agent.Models
{
    public class ShipmentDBContext : DbContext
    {
        public ShipmentDBContext(DbContextOptions<ShipmentDBContext> options) : base(options) { }

        public DbSet<Shipment> Shipments { get; set; }    
    }
}