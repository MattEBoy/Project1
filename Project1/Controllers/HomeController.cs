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
        //TODO: Sarah add iApplicationRepository to models
        //private iApplicationRepository _repository
        public HomeController(ILogger<HomeController> logger) //iApplicationRepository repository
        {
            _logger = logger;
            //TODO: Sarah add iApplicationRepository to models
            //_repository = repository;
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
                //_repository.Appointments.Add(newApt);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }
        //TODO: Ben edit the exisitng AddAppointments.cshtml to be a form with the appointment information
        [HttpGet]
        public IActionResult AddAppointment()
        {
            return View();
        }


        public IActionResult ViewAppointments()
        {
            //TODO: Ben make sure the view appointments is named "ViewAppointments.cshtml"
            

            return View();
            //TODO: Sarah add iApplicationRepository to models
            //return View(_repository.Appointments);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
