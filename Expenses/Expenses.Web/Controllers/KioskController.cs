using Expenses.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Expenses.Web.Controllers
{
    public class KioskController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}