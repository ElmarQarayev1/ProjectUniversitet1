using System;
using Core;

namespace Service
{
	public interface IDoctor
	{
		void Create(Doctor entity);

		void Delete(int id);

		void Update(Doctor entity, int id);

		List<Doctor> GetDoctors();
	}
}
