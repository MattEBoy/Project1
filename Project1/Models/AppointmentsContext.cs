using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Models
{
    public class AppointmentsContext : DbContext
    {
        public AppointmentsContext (DbContextOptions<AppointmentsContext> options) : base (options)
            { }

        public DbSet<Appointment> Appointments { get; set; }
    }
}
