using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Expenses.Web.Controllers.Api
{
    public class KioskAddRowController : ApiController
    {
        public SL.Kiosk.KioskService Service { get; set; }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody]Contracts.Kiosk.AddExpenseRowRequestDto data)
        {
            if (data == null)
                return BadRequest();

            Service.AddExpenseRow(data);
            return Ok();
        }
    }
}