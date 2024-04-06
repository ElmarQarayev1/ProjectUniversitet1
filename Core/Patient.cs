using System;
namespace Core
{
	public class Patient:Human
	{		
		public List<Appointment> Appointments { get; set; }

        public override string ToString()
        {
            return $"Id:{Id}--FullName:{FullName}--Email:{Email}--Password:{Password}";
        }
    }
}
