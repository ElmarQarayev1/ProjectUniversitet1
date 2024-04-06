using System;
using Core;
using Data;
using Microsoft.EntityFrameworkCore;
using Service.Exceptions;

namespace Service
{
    public class PatientService : IPatient//patient interfacesinden metodlar gelir

    {
        AppDbContext _context;

        public PatientService()
        {
            _context = new AppDbContext();
        }
        public void Create(Patient entity)
        {
            _context.Patients.Add(entity);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var entity = _context.Patients.FirstOrDefault(x => x.Id == id);
            if (entity == null)
                throw new EntityNotFoundException("Patient not found..");

            _context.Patients.Remove(entity);
            _context.SaveChanges();
        }

        public List<Patient> GetPatients()
        {
            var patients = _context.Patients.Include(x => x.Appointments).ToList();

            return patients;
        }

        public void Update(Patient entity, int id)
        {
            var existEntity = _context.Patients.FirstOrDefault(x => x.Id == id);

            if (existEntity == null)
                throw new EntityNotFoundException("Entity not found..");

            existEntity.FullName = entity.FullName;
            existEntity.Email = entity.Email;
            existEntity.Password = entity.Password;
            _context.SaveChanges();
        }
    }
}

