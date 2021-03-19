using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Project1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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
                return RedirectToAction("ViewAppointments");
            }
            else
            {
                return View();
            }

        }

        [HttpGet]
        public IActionResult ViewTimes()
        {
            //Creates a string list of all the times/dates in the database
            List<string> takenSlots = new List<string>();
            {
                foreach (var appointment in _context.Appointments)
                {
                    //date time object is converted to a string with formatting to match the view formatting
                    takenSlots.Add(appointment.ApptTime.ToString("MM/dd/yyyy hh:mm tt"));
                }
            }

            //passes that list into the viewbag to be accessed in the view.
            ViewBag.TakenSlots = takenSlots;

            return View();
        }
        [HttpPost]
        public IActionResult ViewTimes(NewDate aptDate)
        {
            
            return RedirectToAction("AddAppointment", aptDate);
        }

        [HttpGet]
        public IActionResult AddAppointment(NewDate aptDate)
        {
            //the date from the ViewTimes view is passed through from the paramter into the viewbag to this view.
            ViewBag.StringDate = aptDate.newAptDate;
            //String is parsed into a datetime class and sent to the view
            DateTime myDate = DateTime.ParseExact(ViewBag.StringDate, "MM/dd/yyyy hh:mm tt", null);
            ViewBag.GetFormatDate = myDate;
            
            return View();
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
