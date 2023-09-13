using BarberShop.Application.Helpers;
using BarberShop.Application.Services.Interfaces;
using BarberShop.Domain;
using BarberShop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Application.Services
{
	public class AppointmentService : IAppointmentService
	{
		private readonly IAppointmentRepository _appointmentRepository;

		public AppointmentService(IAppointmentRepository appointmentRepository)
		{
			_appointmentRepository = appointmentRepository;
		}

		public Appointment CreateAppointment(string name, string email ,DateTime dateTime)
		{
			var appointment = new Appointment() 
			{
				CustomerName = name,
				Email = email,
				Date = dateTime
			};
			if (AppointmentValidator<Appointment>.Validate(appointment))
			{
				_appointmentRepository.Create(appointment);
				return appointment;
			}
			return null;
		}

		public void DeleteAppointment(int id)
		{
			var appointment = new Appointment()
			{
				Id = id
			};
			_appointmentRepository.Delete(appointment);
		}

		public IEnumerable<Appointment> GetAppointments()
		{
			return _appointmentRepository.GetAppointments();
		}

		public IEnumerable<Appointment> GetAppointmentsOfToday()
		{
			return _appointmentRepository.GetAppointments().Where(a => a.Date.Date == DateTime.Today.Date).OrderBy(d=> d.Date);
		}

		public Appointment PatchAppointment(int id, DateTime dateTime)
		{
			var appointment = new Appointment()
			{
				Id = id,
				Date = dateTime
			};
			return _appointmentRepository.Patch(appointment);
		}
	}
}
