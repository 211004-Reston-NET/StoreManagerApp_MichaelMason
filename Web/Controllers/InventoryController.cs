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
    public class InventoryController : Controller
    {
        readonly IInventoryBl inventoryRepository;
        readonly IStorefrontBL storefrontRepository;

        public InventoryController(IInventoryBl context, IStorefrontBL storeContext)
        {
            this.inventoryRepository = context;
            this.storefrontRepository = storeContext;
        }

        // GET: InventoryController
        public ActionResult Index()
        {
            return View(inventoryRepository.GetAllWithNav());
        }

        // GET: InventoryController/Details/5
        public ActionResult Details(int id)
        {
            return View(inventoryRepository.GetByPrimaryKeyWithNav(id));
        }

        // GET: InventoryController/Create
        public ActionResult Create()
        {
            IEnumerable<Storefront> stores = storefrontRepository.GetAll();
            ViewData["stores"] = stores;
            return View();
        }

        // POST: InventoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            IEnumerable<Storefront> stores = storefrontRepository.GetAll();
            ViewData["stores"] = stores;
            
            try
            {
                var inventory = new Inventory
                {
                    StoreNumber = int.Parse(collection["StoreNumber"]),
                    Quantity = int.Parse(collection["Quantity"])
                };

                var product = new Product
                {
                    ProdName = collection["Prod.ProdName"],
                    ProdPrice = decimal.Parse(collection["Prod.ProdPrice"]),
                    ProdDescription = collection["Prod.ProdDescription"],
                    ProdCategory = collection["Prod.ProdCategory"]
                };

                inventory.Prod = product;

                inventoryRepository.Create(inventory);
                inventoryRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                Log.Error(e.Message);
                return View();
            }
        }

        // GET: InventoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(inventoryRepository.GetByPrimaryKeyWithNav(id));
        }

        // POST: InventoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var inventory = inventoryRepository.GetByPrimaryKey(id);
                inventory.Quantity = int.Parse(collection["Quantity"]);
                inventoryRepository.Update(inventory);
                inventoryRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                Log.Error(e.Message);
                return View();
            }
        }

        // GET: InventoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(inventoryRepository.GetByPrimaryKeyWithNav(id));
        }

        // POST: InventoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var inventory = inventoryRepository.GetByPrimaryKeyWithNav(id);
                inventoryRepository.Delete(inventory);
                inventoryRepository.Save();
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
