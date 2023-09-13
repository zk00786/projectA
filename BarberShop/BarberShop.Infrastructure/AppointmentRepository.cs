using BarberShop.Domain;
using System.Data;

namespace BarberShop.Infrastructure
{
	public class AppointmentRepository : IAppointmentRepository
	{
		private readonly AppointmentDbContext _dbContext;

		public AppointmentRepository(AppointmentDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void Create(Appointment appointment)
		{
			_dbContext.Appointments.Add(appointment);
			_dbContext.SaveChanges();
			
		}

		public Appointment Patch(Appointment appointment)
		{
			Appointment? data = IfDataExists(appointment);
			if (data != null)
			{
				_dbContext.Attach(appointment);
				_dbContext.Entry(appointment).Property(r => r.Date).IsModified = true;
				_dbContext.SaveChanges();
				return appointment;
			}
			return data;
		}

		private Appointment? IfDataExists(Appointment appointment)
		{
			return _dbContext.Appointments.Where(x => x.Id == appointment.Id).FirstOrDefault();
		}

		public void Delete(Appointment appointment)
		{
			Appointment? data = IfDataExists(appointment);
			if (data != null)
			{
				_dbContext.Attach(data);
				_dbContext.Remove(data);
				_dbContext.SaveChanges();
			}
		}

		public IEnumerable<Appointment> GetAppointments()
		{
			return _dbContext.Appointments;
		}
	}
}
