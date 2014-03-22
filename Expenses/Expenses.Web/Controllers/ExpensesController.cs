using Expenses.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Expenses.Web.Controllers
{
    public class ExpensesController : Controller
    {
        public BL.UnitOfWorkContext Context { get; set; }

        public ExpenseService Expenses { get; set; }

        public ExpenseIconService Icons { get; set; }
        
        public UserService Users { get; set; }
        
        //
        // GET: /Expenses/
        public ActionResult Index()
        {
            return View(new Models.ExpensesIndexModel()
            {
                Expenses = Expenses.FetchAll()
            });
        }

        //
        // GET: /Expenses/Details/5
        public ActionResult Details(int id)
        {
            var item = Expenses.FetchById(id);
            if (item == null)
                return HttpNotFound();

            return View(new Models.ExpensesDetailsModel()
            {
                Expense = item
            });
        }

        //
        // GET: /Expenses/Create
        [Authorize(Roles = "Administrators")]
        public ActionResult Create(int? userId)
        {
            var model = new Models.ExpensesCreateAndEditModel(true, Icons.FetchAll(), Users.FetchAll());
            model.Expense = new Models.ExpenseModel(Expenses.CreateNew());
            model.Expense.CreatorUserId = userId;
            return View("CreateAndEdit", model);
        }

        //
        // POST: /Expenses/Create
        [Authorize(Roles = "Administrators")]
        [HttpPost]
        public ActionResult Create([Bind(Prefix="Expense")] Models.ExpenseModel value)
        {
            if (!ViewData.ModelState.IsValid)
            {
                var model = new Models.ExpensesCreateAndEditModel(true, Icons.FetchAll(), Users.FetchAll());
                model.Expense = value;
                return View("CreateAndEdit", model);
            }

            // apply to BO
            value.ApplyToBO(Expenses.CreateNew(), Users, Icons);

            // save
            Context.SaveChanges();

            return RedirectToAction("Index");

        }

        //
        // GET: /Expenses/Edit/5
        [Authorize(Roles = "Administrators")]
        public ActionResult Edit(int id)
        {
            var item = Expenses.FetchById(id);
            if (item == null)
                return HttpNotFound();

            var model = new Models.ExpensesCreateAndEditModel(false, Icons.FetchAll(), Users.FetchAll());
            model.Expense = new Models.ExpenseModel(item);
            return View("CreateAndEdit", model);
        }

        //
        // POST: /Expenses/Edit/5
        [Authorize(Roles = "Administrators")]
        [HttpPost]
        public ActionResult Edit(int id, [Bind(Prefix="Expense")] Models.ExpenseModel value)
        {
            var expense = Expenses.FetchById(id);
            if(expense == null)
                return HttpNotFound();

            if(!ViewData.ModelState.IsValid)
            {
                var model = new Models.ExpensesCreateAndEditModel(false, Icons.FetchAll(), Users.FetchAll());
                model.Expense = value;
                return View("CreateAndEdit", model);
            }

            // apply to BO
            value.ApplyToBO(expense, Users, Icons);

            // save
            Context.SaveChanges();

            return RedirectToAction("Index");
        }

        //
        // GET: /Expenses/Delete/5
        [Authorize(Roles = "Administrators")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Expenses/Delete/5
        [Authorize(Roles = "Administrators")]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
