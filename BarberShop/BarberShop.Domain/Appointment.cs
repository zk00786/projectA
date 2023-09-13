namespace BarberShop.Domain;

public class Appointment : IValidatorCommon
{
	public int Id { get; set; }
	public string CustomerName { get; set; }
	public string Email { get; set; }
	public DateTime Date { get; set; }


}
