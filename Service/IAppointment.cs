using System;
using Core;

namespace Service
{
	public interface IAppointment
	{
		void Create(Appointment entity);

		List<Appointment> GetAppointments();

    }
}

