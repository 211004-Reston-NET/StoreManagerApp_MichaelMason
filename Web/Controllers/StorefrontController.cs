using Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class StorefrontController : Controller
    {
        readonly IStorefrontBL repository;

        public StorefrontController(IStorefrontBL context)
        {
            this.repository = context;
        }

        // GET: StorefrontController
        public ActionResult Index()
        {
            return View(repository.GetAll());
        }

        // GET: StorefrontController/Details/5
        public ActionResult Details(int id, string orderSort=null, string priceSort=null)
        {
            var storefront = repository.GetByPrimaryKeyWithNav(id);
            if (orderSort == "asc")
            {
                storefront.SOrders = storefront.SOrders.OrderBy(o => o.OrderId).ToList();
            }
            if (orderSort == "desc")
            {
                storefront.SOrders = storefront.SOrders.OrderByDescending(o => o.OrderId).ToList();
            }
            if (priceSort == "asc")
            {
                storefront.SOrders = storefront.SOrders.OrderBy(o => o.TotalPrice).ToList();
            }
            if (priceSort == "desc")
            {
                storefront.SOrders = storefront.SOrders.OrderByDescending(o => o.TotalPrice).ToList();
            }
            return View(storefront);
        }

        // GET: StorefrontController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StorefrontController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var storefront = new Storefront
                {
                    StoreName = collection["StoreName"],
                    StoreAddress = collection["StoreAddress"],
                };
                repository.Create(storefront);
                repository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                Log.Error(e.Message);
                return View();
            }
        }

        // GET: StorefrontController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repository.GetByPrimaryKey(id));
        }

        // POST: StorefrontController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var storefront = repository.GetByPrimaryKey(id);
                storefront.StoreName = collection["StoreName"];
                storefront.StoreAddress = collection["StoreAddress"];
                repository.Update(storefront);
                repository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                Log.Error(e.Message);
                return View();
            }
        }

        // GET: StorefrontController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(repository.GetByPrimaryKey(id));
        }

        // POST: StorefrontController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var storefront = repository.GetByPrimaryKey(id);
                repository.Delete(storefront);
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
