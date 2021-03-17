using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Models
{
    public class EFAppointmentRepository : iAppointmentRepository
    {
        private AppointmentsContext _context;

        //constructor
        public EFAppointmentRepository(AppointmentsContext context)
        {
            _context = context;
        }
        public IQueryable<Appointment> Books => _context.Appointments;
    
    }
}
