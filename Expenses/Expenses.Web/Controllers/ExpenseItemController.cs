using Expenses.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Expenses.Web.Controllers
{
    public class ExpenseItemController : Controller
    {
        public ExpenseItemService ExpenseItems { get; set; }

        public ExpenseService Expenses { get; set; }

        public UserService Users { get; set; }
        
        public BL.UnitOfWorkContext Context { get; set; }

        //
        // GET: /Expenses/Create
        [Authorize(Roles="Administrators")]
        public ActionResult Create(int expenseId, int? userId)
        {
            var expense = Expenses.FetchById(expenseId);
            if(expense == null)
                return HttpNotFound();

            var model = new Models.ExpenseItemCreateAndEditModel(true, expense, Users.FetchAll());
            model.ExpenseItem = new Models.ExpenseItemModel(ExpenseItems.CreateNew(expense));
            model.ExpenseItem.CreatorUserId = userId;
            return View("CreateAndEdit", model);
        }

        //
        // POST: /Expenses/Create
        [Authorize(Roles = "Administrators")]
        [HttpPost]
        public ActionResult Create(int expenseId, [Bind(Prefix = "ExpenseItem")] Models.ExpenseItemModel value)
        {
            var expense = Expenses.FetchById(expenseId);
            if (expense == null)
                return HttpNotFound();

            if (!ViewData.ModelState.IsValid)
            {
                var model = new Models.ExpenseItemCreateAndEditModel(true, expense, Users.FetchAll());
                model.ExpenseItem = value;
                return View("CreateAndEdit", model);
            }

            // apply to BO
            value.ApplyToBO(ExpenseItems.CreateNew(expense), Users);

            // save
            Context.SaveChanges();

            return RedirectToAction("Details", "Expenses", new { id = expense.Id });
        }

        //
        // GET: /Expenses/Edit/5
        [Authorize(Roles = "Administrators")]
        public ActionResult Edit(int id)
        {
            var item = ExpenseItems.FetchById(id);
            if (item == null)
                return HttpNotFound();

            var model = new Models.ExpenseItemCreateAndEditModel(false, item.Expense, Users.FetchAll());
            model.ExpenseItem = new Models.ExpenseItemModel(item);
            return View("CreateAndEdit", model);
        }

        //
        // POST: /Expenses/Edit/5
        [Authorize(Roles = "Administrators")]
        [HttpPost]
        public ActionResult Edit(int id, [Bind(Prefix="ExpenseItem")] Models.ExpenseItemModel value)
        {
            var item = ExpenseItems.FetchById(id);
            if(item == null)
                return HttpNotFound();

            if(!ViewData.ModelState.IsValid)
            {
                var model = new Models.ExpenseItemCreateAndEditModel(false, item.Expense, Users.FetchAll());
                model.ExpenseItem = value;
                return View("CreateAndEdit", model);
            }

            // apply to BO
            value.ApplyToBO(item, Users);

            // save
            Context.SaveChanges();

            return RedirectToAction("Details", "Expenses", new { id = item.Expense.Id });
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
        [HttpPost]
        [Authorize(Roles = "Administrators")]
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
