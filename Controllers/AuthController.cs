using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shipment_Agent.Models;
using Shipment_Agent.Services;
using Shipment_Agent.Services.Auth;

namespace Shipment_Agent.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthController : Controller
  {
    private ShipmentDBContext _shipmentDBContext;
    public AuthController(ShipmentDBContext shipmentDBContext)
    {
      _shipmentDBContext = shipmentDBContext;
    }
    // Register a new user
    [HttpPost]
    public async Task<JsonResult> Post([FromBody] AuthIncData data)
    {
      try
      {
        var Client = await AuthAndReg.RegisterClient(data, _shipmentDBContext);
        return Json(Client);
      }
      catch (System.Exception ex)
      {
        return Json(ex);
      }

    }
    //
    [HttpDelete]
    public async Task<JsonResult> Delete(AuthIncData data, ShipmentDBContext _shipmentDBContext)
    {
      try
      {
        bool ClientDeleted = await AuthAndReg.DeleteUser(data, _shipmentDBContext);
        if (ClientDeleted)
        {
          return Json(String.Format("Client {0} deleted.", data.Name));
        }
        else
        {
          return Json(String.Format("No client by the name of {0} found.", data.Name));
        }
      }
      catch (System.Exception)
      {
        throw;
      }
    }
  }
}