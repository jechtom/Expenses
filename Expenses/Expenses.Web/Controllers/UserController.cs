using Expenses.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Expenses.Web.Controllers
{
    public class UserController : Controller
    {
        public UserService Users { get; set; }

        public BL.UnitOfWorkContext Context { get; set; }

        //
        // GET: /Expenses/
        public ActionResult Index()
        {
            return View(new Models.UserIndexModel()
            {
                Users = Users.FetchAll()
            });
        }

        //
        // GET: /Expenses/Details/5
        public ActionResult Details(int id)
        {
            var item = Users.FetchById(id);
            if (item == null)
                return HttpNotFound();

            return View(new Models.UserDetailsModel(item));
        }

        //
        // GET: /Expenses/Create
        [Authorize(Roles = "Administrators")]
        public ActionResult Create()
        {
            var model = new Models.UserCreateAndEditModel(true);
            model.User = new Models.UserModel();
            return View("CreateAndEdit", model);
        }

        //
        // POST: /Expenses/Create
        [Authorize(Roles = "Administrators")]
        [HttpPost]
        public ActionResult Create([Bind(Prefix="User")] Models.UserModel value)
        {
            if (!ViewData.ModelState.IsValid)
            {
                var model = new Models.UserCreateAndEditModel(true);
                model.User = value;
                return View("CreateAndEdit", model);
            }

            // apply to BO
            value.ApplyToBO(Users.CreateNew());

            // save
            Context.SaveChanges();

            return RedirectToAction("Index");

        }

        //
        // GET: /Expenses/Edit/5
        [Authorize(Roles = "Administrators")]
        public ActionResult Edit(int id)
        {
            var item = Users.FetchById(id);
            if (item == null)
                return HttpNotFound();

            var model = new Models.UserCreateAndEditModel(false);
            model.User = new Models.UserModel(item);
            return View("CreateAndEdit", model);
        }

        //
        // POST: /Expenses/Edit/5
        [Authorize(Roles = "Administrators")]
        [HttpPost]
        public ActionResult Edit(int id, [Bind(Prefix="User")] Models.UserModel value)
        {
            var user = Users.FetchById(id);
            if(user == null)
                return HttpNotFound();

            if(!ViewData.ModelState.IsValid)
            {
                var model = new Models.UserCreateAndEditModel(false);
                model.User = value;
                return View("CreateAndEdit", model);
            }

            // apply to BO
            value.ApplyToBO(user);

            // save
            Context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
