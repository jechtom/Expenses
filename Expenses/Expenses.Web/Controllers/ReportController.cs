using Expenses.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Expenses.Web.Controllers
{
    public class ReportController : Controller
    {
        public ExpensesReportService ReportService { get; set; }
        public ActionResult Index()
        {
            return View(ReportService.GenerateReport());
        }
	}
}