using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salon.WebUI.Controllers
{
    public class BeautySalonController : Controller
    {
        // GET: BeautySalonController
        public ActionResult Index()
        {
            return View();
        }

        // GET: BeautySalonController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BeautySalonController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BeautySalonController/Create
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

        // GET: BeautySalonController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BeautySalonController/Edit/5
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

        // GET: BeautySalonController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BeautySalonController/Delete/5
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
