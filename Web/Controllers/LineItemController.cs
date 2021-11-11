using Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class LineItemController : Controller
    {
        readonly ILineItemBL lineItemRepository;
        readonly IProductBL productRepository;
        readonly ISOrderBL orderRepository;

        private static LineItem lineItem;

        public LineItemController(ILineItemBL context, IProductBL prodContext, ISOrderBL orderContext)
        {
            this.lineItemRepository = context;
            this.productRepository = prodContext;
            this.orderRepository = orderContext;
        }

        // GET: LineItemController
        public ActionResult Index()
        {
            return View(lineItemRepository.GetAllWithNav());
        }

        // GET: LineItemController/Details/5
        public ActionResult Details(int id)
        {
            return View(lineItemRepository.GetByPrimaryKeyWithNav(id));
        }

        // GET: LineItemController/Create
        public ActionResult Create()
        {
            IEnumerable<SOrder> orders = orderRepository.GetAll();
            IEnumerable<Product> products = productRepository.GetAll();
            ViewData["orders"] = orders;
            ViewData["products"] = products;
            lineItem = new LineItem();
            return View();
        }

        // POST: LineItemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                lineItem.OrderId = int.Parse(collection["OrderId"]);
                lineItem.ProdId = int.Parse(collection["ProdId"]);
                lineItem.Quantity = int.Parse(collection["Quantity"]);
               
                lineItemRepository.Create(lineItem);
                lineItemRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LineItemController/Edit/5
        public ActionResult Edit(int id)
        {
            IEnumerable<SOrder> orders = orderRepository.GetAll();
            IEnumerable<Product> products = productRepository.GetAll();
            ViewData["orders"] = orders;
            ViewData["products"] = products;
            return View(lineItemRepository.GetByPrimaryKeyWithNav(id));
        }

        // POST: LineItemController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            IEnumerable<SOrder> orders = orderRepository.GetAll();
            IEnumerable<Product> products = productRepository.GetAll();
            ViewData["orders"] = orders;
            ViewData["products"] = products;
            try
            {
                var lineItem = lineItemRepository.GetByPrimaryKey(id);
                lineItem.ProdId = int.Parse(collection["ProdId"]);
                lineItem.OrderId = int.Parse(collection["OrderId"]);
                lineItem.Quantity = int.Parse(collection["Quantity"]);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LineItemController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(lineItemRepository.GetByPrimaryKeyWithNav(id));
        }

        // POST: LineItemController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var lineItem = lineItemRepository.GetByPrimaryKeyWithNav(id);
                lineItemRepository.Delete(lineItem);
                lineItemRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
