using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Expenses.Web.Controllers.Api
{
    [EnableCors("*", "*", "GET")]
    public class KioskExpensesController : ApiController
    {
        public SL.Kiosk.KioskService Service { get; set; }

        // GET api/<controller>
        public IHttpActionResult Get()
        {
            var data = Service.GetExpensesWithKioskEnabled();
            return Json(data);
        }
    }
}