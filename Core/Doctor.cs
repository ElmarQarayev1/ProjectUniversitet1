using System;
namespace Core
{
	public class Doctor
	{
        public int Id { get; set; }

        public string? FullName { get; set; }

        public string? Email { get; set; }

        public List<Appointment> Appointments { get; set; }

        public override string ToString()
        {
            return $"Id:{Id}--FullName:{FullName}--Email:{Email}";
        }
    }
}

