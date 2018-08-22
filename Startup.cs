using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Shipment_Agent.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Shipment_Agent.Utils;

namespace Shipment_Agent
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;

    }
    public IConfiguration Configuration { get; }
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc()
        .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

      /* Gain access to JWT secret and set token master's secret, if custom secret is not set in the configurations uses default secret */
      var secretString = Configuration.GetValue("Secret", "8gcK2WJBNFaH8deTWmRadZLvE67L8c29NfsdCAA8waHdX3kbYWJywU92bNVpZtJjmLAQhX");
      Utils.TokenMaster.SetSecret(secretString);
      /* DB configuration */
      var connectionString = Configuration.GetConnectionString("ShipmentDBContext");
      services.AddEntityFrameworkNpgsql()
        .AddDbContext<ShipmentDBContext>(options => 
          options.UseNpgsql(connectionString, b => b.MigrationsAssembly("Shipment_Agent")));
    }
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseMvc();
    }
  }
}
