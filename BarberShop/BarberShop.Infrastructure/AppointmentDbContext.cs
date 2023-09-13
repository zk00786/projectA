using BarberShop.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace BarberShop.Infrastructure;

public class AppointmentDbContext : DbContext
{

	public AppointmentDbContext(DbContextOptions<AppointmentDbContext> options) : base(options)
	{
		try
		{
			var creater = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
			if (creater != null)
			{
				if (!creater.CanConnect()) creater.Create();
				if (!creater.HasTables()) creater.CreateTables();
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}

	public DbSet<Appointment> Appointments { get; set; }
}
