using BarberShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Application.Services.Interfaces
{
	public interface IAppointmentService
	{
		Appointment CreateAppointment(string name, string email, DateTime dateTime);
		Appointment PatchAppointment(int id, DateTime dateTime);
		void DeleteAppointment(int id);
		IEnumerable<Appointment> GetAppointments();
		IEnumerable<Appointment> GetAppointmentsOfToday();
	}
}
