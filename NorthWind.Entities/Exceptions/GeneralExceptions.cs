using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Entities.Exceptions
{
	public class GeneralExceptions : Exception
	{
		public string Details { get; set; }

		public GeneralExceptions() { }

		public GeneralExceptions(string message) : base(message) { }

		public GeneralExceptions(string message,
			Exception innerException) : base(message, innerException) { }

		public GeneralExceptions(string title, string detail) : base(title) => Details = detail;
	}
}
