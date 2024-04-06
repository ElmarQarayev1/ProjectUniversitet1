using System;
namespace Core
{
	public class Patient:Human//inheritance prinsipi
	{		
		public List<Appointment> Appointments { get; set; }

        public override string ToString()
        {
            return $"Id:{Id}--FullName:{FullName}--Email:{Email}--Password:{Password}";
        }
    }
}
