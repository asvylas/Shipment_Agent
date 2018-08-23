using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shipment_Agent.Models;
using Shipment_Agent.Services.Auth;
using Shipment_Agent.Classes;

namespace Shipment_Agent.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : Controller
  {
    private ShipmentDBContext _shipmentDBContext;
    public UserController(ShipmentDBContext shipmentDBContext)
    {
      _shipmentDBContext = shipmentDBContext;
    }
    // Register a new user
    [HttpPost]
    public async Task<JsonResult> Post([FromBody] UserLogin data)
    {
      try
      {
        var client = await LoginAndRegistration.RegisterClient(data, _shipmentDBContext);
        var token = Services.Auth.TokenMaster.GenerateToken(data.Name);
        return Json(token);
      }
      catch (System.Exception ex)
      {
        return Json(ex);
      }
    }
    [HttpPut]
    public JsonResult Put([FromBody] UserToken data)
    {
      try
      {
        var token = TokenMaster.ValidateToken(data.Token);
        return Json(token);
      }
      catch (System.Exception)
      {
          throw;
      }
    }
    //
    [HttpDelete]
    public async Task<JsonResult> Delete(UserLogin data)
    {
      try
      {
        bool clientDeleted = await LoginAndRegistration.DeleteUser(data, _shipmentDBContext);
        if (clientDeleted)
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