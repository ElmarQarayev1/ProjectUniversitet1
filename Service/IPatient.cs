using System;
using Core;

namespace Service
{
	public interface IPatient
	{
        void Create(Patient entity);

        void Delete(int id);

        void Update(Patient entity, int id);

        List<Patient> GetPatients();
    }
}

