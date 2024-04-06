using System;
using Core;
using Data;
using Microsoft.EntityFrameworkCore;
using Service.Exceptions;

namespace Service
{
	public class DoctorService:IDoctor//doctor interfacesinden metodlar gelir
	{
        AppDbContext _context;

        public DoctorService()
        {
            _context = new AppDbContext();
        }

        public void Create(Doctor entity)
        {
            _context.Doctors.Add(entity);
            _context.SaveChanges();

        }

        public void Delete(int id)
        {
            var entity = _context.Doctors.FirstOrDefault(x => x.Id == id);
            if (entity == null)
                throw new EntityNotFoundException("Doctor not found..");

            _context.Doctors.Remove(entity);
            _context.SaveChanges();
        }

        public List<Doctor> GetDoctors()
        {
            return _context.Doctors.Include(x => x.Appointments).ToList();
        }

        public void Update(Doctor entity, int id)
        {
            var existEntity = _context.Doctors.FirstOrDefault(x => x.Id == id);

            if (existEntity == null)
                throw new EntityNotFoundException("Doctor not found..");

            existEntity.FullName = entity.FullName;
            existEntity.Email = entity.Email;

            _context.SaveChanges();
        }
    }
}

