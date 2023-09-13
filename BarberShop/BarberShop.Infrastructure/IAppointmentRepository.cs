using BarberShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Infrastructure
{
	public interface IAppointmentRepository
	{
		void Create(Appointment order);
		IEnumerable<Appointment> GetAppointments();
		Appointment Patch(Appointment appointment);
		void Delete(Appointment appointment);
	}
}
