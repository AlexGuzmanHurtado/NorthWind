using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using NorthWind.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.WebExceptionsPresenter
{
	public class GeneralExceptionHandler : ExceptionHandlerBase, IExceptionHandler
	{
		public Task Handle(ExceptionContext context)
		{
			var Exception = context.Exception as GeneralExceptions;
			return SetResult(context, StatusCodes.Status500InternalServerError,
				Exception.Message, Exception.Details);
		}
	}
	{

	}
}
