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
using Shipment_Agent.Utils;

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
    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<string>> Get()
    {
      return new string[] { "value1", "value2" };
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<string> Get(int id)
    {
      return "value";
    }

    //POST api/values
    [HttpPost]
    public async Task<JsonResult> Post([FromBody] Utils.Auth data)
    {
      try
      {
        var Client = await Reg.RegisterClient(data, _shipmentDBContext);
        return Json(Client);
      }
      catch (System.Exception ex)
      {
        return Json(ex);
      }

    }

    // PUT api/values/5
    [HttpPut]
    public async Task<JsonResult> Put([FromBody] Utils.Auth data )
    {
      try
      {
        var Client = await Reg.AuthenticateClient(data, _shipmentDBContext);
        return Json(Client);
      }
      catch (System.Exception ex)
      {
        return Json(ex);
      }
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}