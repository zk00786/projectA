using BarberShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Application.Helpers
{
	internal static class AppointmentValidator<T> where T : IValidatorCommon
	{
		internal static bool Validate(T app)
		{
			if(app != null)
			{
				return ValidEmailAddress(app.Email) && ValidDate(app.Date);
			}
			return false;
		}

		private static bool ValidEmailAddress(string emailAddress)
		{
			var valid = true;

			try
			{
				var email = new MailAddress(emailAddress);
			}
			catch
			{
				valid = false;
			}

			return valid;
		}

		private static bool ValidDate(DateTime date)
		{
			return true; // we can validate based on use cases
		}
	}
}
