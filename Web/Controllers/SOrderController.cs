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
        readonly ISOrderBL orderRepository;
        readonly ICustomerBL customerRepository;
        readonly IStorefrontBL storefrontRepository;
        readonly IProductBL productRepository;

        public SOrderController(ISOrderBL context, ICustomerBL custContext, IStorefrontBL storeContext, IProductBL productContext)
        {
            this.orderRepository = context;
            this.customerRepository = custContext;
            this.storefrontRepository = storeContext;
            this.productRepository = productContext;
        }

        // GET: SOrderController
        public ActionResult Index()
        {
            return View(orderRepository.GetAllWithNav());
        }

        // GET: SOrderController/Details/5
        public ActionResult Details(int id)
        {
            return View(orderRepository.GetByPrimaryKeyWithNav(id));
        }

        // GET: SOrderController/Create
        public ActionResult Create()
        {
            IEnumerable<Customer> customers = customerRepository.GetAll();
            IEnumerable<Storefront> stores = storefrontRepository.GetAll();
            IEnumerable<Product> products = productRepository.GetAll();
            ViewData["customers"] = customers;
            ViewData["stores"] = stores;
            ViewData["products"] = products;
            ViewData["lineItem"] = new LineItem();
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
                    TotalPrice = decimal.Parse(collection["TotalPrice"])
                };
                orderRepository.Create(order);
                orderRepository.Save();
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
            IEnumerable<Customer> customers = customerRepository.GetAll();
            IEnumerable<Storefront> stores = storefrontRepository.GetAll();
            ViewData["customers"] = customers;
            ViewData["stores"] = stores;
            return View(orderRepository.GetByPrimaryKey(id));
        }

        // POST: SOrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var order = orderRepository.GetByPrimaryKey(id);
                order.CustNumber = int.Parse(collection["CustNumber"]);
                order.StoreNumber = int.Parse(collection["StoreNumber"]);
                order.TotalPrice = decimal.Parse(collection["TotalPrice"]);
                orderRepository.Update(order);
                orderRepository.Save();
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
            return View(orderRepository.GetByPrimaryKeyWithNav(id));
        }

        // POST: SOrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var order = orderRepository.GetByPrimaryKeyWithNav(id);
                orderRepository.Delete(order);
                orderRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
