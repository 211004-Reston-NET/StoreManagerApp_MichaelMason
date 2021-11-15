using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;

namespace Web.Controllers
{
    public class SkiResortController : Controller
    {
        readonly SkiResortBL repository;
        public SkiResortController(SkiResortBL context)
        {
            repository = context;
        }

        public IActionResult Index(string query)
        {
            if (query == null)
            {
                return View(repository.GetAllResorts());
            }
            return View(repository.SearchByName(query));
        }

        public ActionResult Details(int id)
        {
            return View(repository.GetByPrimaryKey(id));
        }
    }
}
