using Expenses.BL;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Expenses.Web.Controllers
{
    public class ExpenseIconController : Controller
    {
        [Dependency]
        public ExpenseIconService IconService { get; set; }

        public ActionResult GetFile(int id)
        {
            var icon = IconService.FetchById(id);
            if (icon == null)
                return HttpNotFound();

            return File(icon.Data, icon.ContentType);
        }
	}
}