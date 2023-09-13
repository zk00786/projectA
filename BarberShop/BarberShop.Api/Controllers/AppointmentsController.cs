using BarberShop.Application.Services.Interfaces;
using BarberShop.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AppointmentsController : ControllerBase
{
    private readonly IAppointmentService _appointmentService;


	private readonly ILogger<AppointmentsController> _logger;

    public AppointmentsController(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;

	}

	[HttpPost]
	public async Task<ActionResult<Appointment>> PostAppointment(string customername, string email, DateTime dateTime)
	{
		var appointment = _appointmentService.CreateAppointment(customername, email, dateTime);
		if (appointment != null)
		{
			return CreatedAtAction(nameof(PostAppointment), new { id = appointment.Id }, appointment);
		}
		return BadRequest();
	}

	[HttpGet("GetAppointments")]
	public IEnumerable<Appointment> GetAppointments()
	{
		return _appointmentService.GetAppointments()
		.ToArray();
	}

	[HttpGet("GetTodaysAppointment")]
	public IEnumerable<Appointment> GetAppointmentsOfToday()
	{
		return _appointmentService.GetAppointmentsOfToday()
		.ToArray();
	}

	[HttpPatch]
	public async Task<ActionResult<Appointment>> PatchAppointment(int id, DateTime dateTime)
	{
		var appointment = _appointmentService.PatchAppointment(id, dateTime);
		if(appointment != null)
		{
			return CreatedAtAction(nameof(PostAppointment), new { id = appointment.Id }, appointment);
		}
		return NotFound();
	}

	[HttpDelete]
	public async Task<ActionResult> DeleteAppointment(int id)
	{
		_appointmentService.DeleteAppointment(id);
		return Ok();
	}
}
