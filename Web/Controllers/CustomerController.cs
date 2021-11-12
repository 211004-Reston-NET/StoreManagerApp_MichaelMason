using System;
using Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Serilog;

namespace Web.Controllers
{
    public class CustomerController : Controller
    {
        readonly ICustomerBL repository;

        public CustomerController(ICustomerBL context)
        {
            this.repository = context;
        }

        // GET: HomeController1
        public ActionResult Index()
        {
            return View(repository.GetAll());
        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            return View(repository.GetByPrimaryKeyWithNav(id));
        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var customer = new Customer
                {
                    CustName = collection["CustName"],
                    CustEmail = collection["CustEmail"],
                    CustAddress = collection["CustAddress"],
                    CustPhone = collection["CustPhone"]
                };
                repository.Create(customer);
                repository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                Log.Error(e.Message);
                return View();
            }
        }

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repository.GetByPrimaryKey(id));
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var customer = repository.GetByPrimaryKey(id);
                customer.CustName = collection["CustName"];
                customer.CustAddress = collection["CustAddress"];
                customer.CustEmail = collection["CustEmail"];
                customer.CustPhone = collection["CustPhone"];
                repository.Update(customer);
                repository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                Log.Error(e.Message);
                return View(repository.GetByPrimaryKey(id));
            }
        }

        // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View(repository.GetByPrimaryKey(id));
        }

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var customer = repository.GetByPrimaryKey(id);
                repository.Delete(customer);
                repository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                Log.Error(e.Message);
                return View();
            }
        }
    }
}
