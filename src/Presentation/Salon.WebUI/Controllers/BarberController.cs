using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salon.WebUI.Controllers
{
    public class BarberController : Controller
    {
        private readonly IAppointmentRepository _repository;
        private readonly ILogger<AppointmentController> _logger;



        public AppointmentController(IAppointmentRepository repository, ILogger<AppointmentController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: BarberController
        public ActionResult ViewBarber()
        {
            return View();
        }

        // GET: BarberController/Details/5
        public ActionResult EditBarber(int id)
        {
            return View();
        }

        // GET: BarberController/Create
        public ActionResult CreateBaraber()
        {
            return View();
        }

        // POST: BarberController/Create
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

        // GET: BarberController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BarberController/Edit/5
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

        // GET: BarberController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BarberController/Delete/5
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
