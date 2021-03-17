using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Project1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private AppointmentsContext _context;
        public HomeController(ILogger<HomeController> logger, AppointmentsContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        //this method posts the appointment, if the appointment is valid it takes the user back to the home page
        [HttpPost]
        public IActionResult AddAppointment(Appointment newApt)
        {
            if (ModelState.IsValid)
            {
                _context.Appointments.Add(newApt);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }

        [HttpGet]
        public IActionResult ViewTimes()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ViewTimes(DateTime newAptDate)
        {
            return RedirectToAction("AddAppointment", newAptDate);
        }

        [HttpGet]
        public IActionResult AddAppointment(DateTime newAptDate)
        {
            return View(newAptDate);
        }
        public IActionResult ViewAppointments(Appointment apt)
        {
            //return View();
            return View(_context.Appointments);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
