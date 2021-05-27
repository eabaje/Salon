using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salon.WebUI.Controllers
{
    public class ServiceTypeController : Controller
    {
        // GET: ServiceTypeController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ServiceTypeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ServiceTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServiceTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ServiceTypeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ServiceTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ServiceTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ServiceTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
