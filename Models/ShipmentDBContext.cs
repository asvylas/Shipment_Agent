using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.Extensions.Configuration;

namespace Shipment_Agent.Models
{
  public class ShipmentDBContext : DbContext
  {
    public ShipmentDBContext(DbContextOptions<ShipmentDBContext> options) : base(options)
    {

    }
    public DbSet<Shipment> Shipments { get; set; }
    public DbSet<ClientAuth> ClientAuths { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<ClientAuth>()
          .HasIndex(b => b.NAME)
          .IsUnique();
      modelBuilder.Entity<Shipment>()
          .Property(a => a.Created)
          .HasDefaultValueSql("NOW()");
      modelBuilder.Entity<Shipment>()
          .Property(a => a.Status)
          .HasDefaultValue("1");
    }
  }
}