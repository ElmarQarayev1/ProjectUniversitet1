using System;
using Core;
using Microsoft.EntityFrameworkCore;

namespace Data
{
	public class AppDbContext:DbContext
	{
        public DbSet<Patient> Patients { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=HospitalSystem;User ID=sa; Password=reallyStrongPwd123;TrustServerCertificate=true;");
        }
    }
}
