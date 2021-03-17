using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Models
{
    public class SeedData
    {
        public static void EnsurePopulated (IApplicationBuilder application)
        {
            AppointmentsContext context = application.ApplicationServices.
                CreateScope().ServiceProvider.GetRequiredService<AppointmentsContext>();

            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if(!context.Appointments.Any())
            {
                context.Appointments.AddRange(

                    new Appointment
                    {
                        GroupName = "Smith Group",
                        GroupSize = 4,
                        GroupEmail = "smith@email.com",
                        ApptTime = new DateTime(2021, 05, 01)
                    },

                    new Appointment
                    {
                        GroupName = "Johnson Group",
                        GroupSize = 4,
                        GroupEmail = "johnson@email.com",
                        ApptTime = new DateTime(2021, 05, 02),
                    },

                    new Appointment
                    {
                        GroupName = "Thomas Group",
                        GroupSize = 2,
                        GroupEmail = "thomas@email.com",
                        ApptTime = new DateTime(2021, 05, 03),
                    },

                    new Appointment
                    {
                        GroupName = "Larrry Group",
                        GroupSize = 3,
                        GroupEmail = "larry@email.com",
                        ApptTime = new DateTime(2021, 05, 04),
                    },

                    new Appointment
                    {
                        GroupName = "Sally Group",
                        GroupSize = 8,
                        GroupEmail = "sally@email.com",
                        ApptTime = new DateTime(2021, 05, 05),
                    },

                    new Appointment
                    {
                        GroupName = "Sam Group",
                        GroupSize = 1,
                        GroupEmail = "sam@email.com",
                        ApptTime = new DateTime(2021, 05, 06),
                    }
                    );

                //save all changes
                context.SaveChanges();
            }
        }
    }
}
