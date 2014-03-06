using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Expenses.Web.Controllers.Api
{
    [EnableCors]
    public class KioskController : ApiController
    {
        public SL.Kiosk.KioskService Service { get; set; }

        // GET api/<controller>
        public IHttpActionResult Get()
        {
            return NotFound();
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            var data = Service.GetScreenDataForExpense(id);
            if (data == null)
                return NotFound();
            return Json(data);
        }
    }
}