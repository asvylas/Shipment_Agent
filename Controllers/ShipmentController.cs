using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
    public ActionResult<string> Get(int id)
    {
      return "value";
    }

    // POST api/values
    [HttpPost]
    public async Task<JsonResult> PostAsync([FromBody] Shipment data, [FromHeader] string token)
    {
      string username;
      Models.ClientAuth client;
      Shipment shipment;

      username = TokenMaster.ValidateToken(token);
      client = _shipmentDBContext.ClientAuths
        .Where(a => a.NAME == username)
        .First();
      if (client.ID == data.ClientID)
      {
        shipment = await ShipmentMaster.CreateShipment(data, _shipmentDBContext);
        return Json(shipment);
      }
      else
      {
        return Json("");
      }
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
