using System;
using Core;
using Data;
using Microsoft.EntityFrameworkCore;
using Service.Exceptions;

namespace Service
{
	public class AppointmentService:IAppointment
	{
        AppDbContext _context;

        public AppointmentService()
        {
            _context = new AppDbContext();
        }

        public void Create(Appointment entity)
        {
            if (!_context.Doctors.Any(x => x.Id == entity.DoctorId))
                throw new EntityNotFoundException("Doctor not found..");

            if (!_context.Patients.Any(x => x.Id == entity.PatientId))
                throw new EntityNotFoundException("Patient not found..");

            _context.Appointments.Add(entity);
            _context.SaveChanges();
        }
        public List<Appointment> GetAppointments()
        {
            return _context.Appointments.Include(x => x.Doctor).ToList();
        }

    }
}

