using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shipment_Agent.Models;
using Shipment_Agent.Services.Auth;
using Shipment_Agent.Services.Shipment;

namespace Shipment_Agent.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ShipmentController : Controller
  {
    private ShipmentDBContext _shipmentDBContext;
    public ShipmentController(ShipmentDBContext shipmentDBContext)
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
    public async Task<JsonResult> Get(int id, [FromHeader] string token)
    {
      string mystring = "a";
      string username;
      List<Models.Shipment> list;
      bool flag;

      try
      {
        username = TokenMaster.ValidateToken(token);
        flag = _shipmentDBContext.ClientAuths.Where(a => a.NAME == username).Count() > 0;
        if (!flag)
        {
          list = (_shipmentDBContext.Shipments.Where(a => a.ClientID == id)).ToList();
          return Json(list);
        }
        else
        {
          throw new System.Exception("Something failed along the way.");
        }
      }
      catch (System.Exception)
      {
        throw;
      }

    }

    // POST api/values
    [HttpPost]
    public async Task<JsonResult> Post([FromBody] Shipment data, [FromHeader] string token)
    {
      string username;
      Models.ClientAuth client;
      Shipment shipment;

      try
      {
        username = TokenMaster.ValidateToken(token);
        client = _shipmentDBContext.ClientAuths
          .Where(a => a.NAME == username)
          .First();
        if (client.ID == data.ClientID)
        {
          shipment = await ShipmentMaster.CreateShipment(data, _shipmentDBContext);
          return Json(shipment.ShipmentID);
        }
        else
        {
          throw new System.Exception("Wrong client ID.");
        }
      }
      catch (System.Exception)
      {
        throw;
      }
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {

    }
  }
}
