using Hospital.Logic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Persistence
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; } = null!;

        public DbSet<Patient> Patients { get; set; } = null!;

        public DbSet<Office> Offices { get; set; } = null!;

        public DbSet<HospitalSite> HospitalSites { get; set; } = null!;

        public DbSet<Specialization> Specializations { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}

    }
}
