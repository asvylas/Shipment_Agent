using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shipment_Agent.Models;

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
    public async Task<JsonResult> PostAsync([FromBody] Shipment data)
    {
      try
      {
        data.ShipmentID = Shipment.GenerateID(data.ClientID);
        List<Shipment> list = new List<Shipment>();
        await _shipmentDBContext.Shipments.AddAsync(data);
        await _shipmentDBContext.SaveChangesAsync();
        var shipment =  _shipmentDBContext.Shipments
          .Where(a=> a.ShipmentID == data.ShipmentID).First();
        // foreach (var item in _shipmentDBContext.Shipments)
        // {
        //   list.Add(item);
        // }
        return Json(shipment);
      }
      catch (System.Exception ex)
      {
        return Json(ex);
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
