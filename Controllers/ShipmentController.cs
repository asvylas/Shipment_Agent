using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shipment_Agent.Classes;
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
    public JsonResult Post([FromBody] Shipment data)
    {
      List<Shipment> list = new List<Shipment>();
      _shipmentDBContext.Shipments.Add(data);
      _shipmentDBContext.SaveChanges();

      foreach (var item in _shipmentDBContext.Shipments)
      {
        list.Add(item);
      }
      return Json(list);
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
