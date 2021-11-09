using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Models;

namespace Web.Controllers
{
    public class SOrderController : Controller
    {
        readonly ISOrderBL repository;

        public SOrderController(ISOrderBL context)
        {
            this.repository = context;
        }

        // GET: SOrderController
        public ActionResult Index()
        {
            return View(repository.GetAll());
        }

        // GET: SOrderController/Details/5
        public ActionResult Details(int id)
        {
            return View(repository.GetByPrimaryKeyWithNav(id));
        }

        // GET: SOrderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SOrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var order = new SOrder
                {
                    CustNumber = int.Parse(collection["CustNumber"]),
                    StoreNumber = int.Parse(collection["StoreNumber"]),
                    TotalPrice = 0
                };
                repository.Create(order);
                repository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SOrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repository.GetByPrimaryKey(id));
        }

        // POST: SOrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var order = repository.GetByPrimaryKey(id);
                order.CustNumber = int.Parse(collection["CustNumber"]);
                order.StoreNumber = int.Parse(collection["StoreNumber"]);
                order.TotalPrice = int.Parse(collection["TotalPrice"]);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SOrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(repository.GetByPrimaryKey(id));
        }

        // POST: SOrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var order = repository.GetByPrimaryKey(id);
                repository.Delete(order);
                repository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
