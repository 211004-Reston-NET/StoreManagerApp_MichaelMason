using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Models;
using Serilog;

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
            IEnumerable<Customer> customers = customerRepository.GetAll();
            IEnumerable<Storefront> stores = storefrontRepository.GetAll();
            IEnumerable<Product> products = productRepository.GetAll();
            ViewData["customers"] = customers;
            ViewData["stores"] = stores;
            ViewData["products"] = products;
            ViewData["lineItem"] = new LineItem();
            try
            {
                List<int> productIds = new List<int>();
                List<int> lineQuantities = new List<int>();
                foreach (var item in collection)
                {
                    if (item.Key.Contains("productId"))
                    {
                        productIds.Add(int.Parse(item.Value));
                    }
                    if (item.Key.Contains("lineQuant"))
                    {
                        lineQuantities.Add(int.Parse(item.Value));
                    }
                }

                var order = new SOrder
                {
                    CustNumber = int.Parse(collection["CustNumber"]),
                    StoreNumber = int.Parse(collection["StoreNumber"]),
                    TotalPrice = 0
                };

                LineItem newLine = new LineItem();

                newLine.ProdId = int.Parse(collection["ViewData[products.ProdId]"]);
                newLine.Quantity = int.Parse(collection["ViewData[lineItem.Quantity]"]);

                order.LineItems.Add(newLine);

                for (var i=0; i < productIds.Count; i++)
                {
                    newLine = new LineItem
                    {
                        Prod = productRepository.GetByPrimaryKeyWithNav(productIds[i]),
                        Quantity = lineQuantities[i]
                    };
                    order.LineItems.Add(newLine);
                }

                foreach (var item in order.LineItems)
                {
                    int id = 0;
                    if (item.ProdId == null)
                    {
                        id = item.Prod.ProdId;
                    }
                    else
                    {
                        id = (int)item.ProdId;
                    }
                    order.TotalPrice += orderRepository.UpdateTotalPrice(id, item.Quantity);

                    orderRepository.UpdateInventoryOnSale(id, item.Quantity);
                }
                orderRepository.Create(order);
                orderRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                Log.Error(e.Message);
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
            catch(Exception e)
            {
                Log.Error(e.Message);
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
            catch(Exception e)
            {
                Log.Error(e.Message);
                return View();
            }
        }
    }
}
