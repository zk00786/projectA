using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Domain
{
	public interface IValidatorCommon
	{
		string Email { get; set; }
		DateTime Date { get; set; }
	}
}
