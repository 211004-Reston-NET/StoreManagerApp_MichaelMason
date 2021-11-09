using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Business;

namespace Web.Controllers
{
    public class ProductController : Controller
    {
        readonly IProductBL repository;

        public ProductController(IProductBL context)
        {
            this.repository = context;
        }

        // GET: ProductController
        public ActionResult Index()
        {
            return View(repository.GetAll());
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View(repository.GetByPrimaryKeyWithNav(id));
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var product = new Product
                {
                    ProdName = collection["ProdName"],
                    ProdPrice = decimal.Parse(collection["ProdPrice"]),
                    ProdDescription = collection["ProdDescription"],
                    ProdCategory = collection["ProdCategory"]
                };
                repository.Create(product);
                repository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repository.GetByPrimaryKey(id));
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var product = repository.GetByPrimaryKey(id);
                product.ProdName = collection["ProdName"];
                product.ProdPrice = decimal.Parse(collection["ProdPrice"]);
                product.ProdDescription = collection["ProdDescription"];
                product.ProdCategory = collection["ProdCategory"];
                repository.Update(product);
                repository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(repository.GetByPrimaryKey(id));
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(repository.GetByPrimaryKey(id));
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var product = repository.GetByPrimaryKey(id);
                repository.Delete(product);
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
