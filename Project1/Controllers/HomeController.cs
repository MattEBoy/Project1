using Microsoft.AspNetCore.Mvc;
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
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
                //this doesn't work until the repo is created 
                //_context.Appointments.Add(newApt);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }
        [HttpGet]
        public IActionResult AddAppointment()
        {
            return View();
        }

        public IActionResult ViewAppointments()
        {
            //name the view appointments view "ViewAppointments.cshtml"
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
