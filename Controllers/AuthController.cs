using System;
using System.Collections.Generic;
using System.Linq;
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
    public JsonResult Post([FromBody] ClientReg data)
    {
      try
      {
        (string hash, string salt) = data.RegisterClient(data.NAME, data.PASSWORD);
        var Client = new Models.ClientAuth()
        {
          SALT = salt,
          HASH = hash,
          NAME = data.NAME
        };
        return Json(Client);
      }
      catch (System.Exception)
      {
        throw;
      }

    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}