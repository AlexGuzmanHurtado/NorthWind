﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using NorthWind.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.WebExceptionsPresenter
{
	public class ValidationExceptionHandler : ExceptionHandlerBase, IExceptionHandler
	{
		public Task Handle(ExceptionContext context)
		{
			var Exception = context.Exception as ValidationException;
			StringBuilder builder = new StringBuilder();
			foreach(var Failure in Exception.Error)
			{
				builder.AppendLine(
					string.Format("Propiedad: {0}. Error: {1}",
					Failure.PropertyName, Failure.ErrorMessage));
			}
			return SetResult(context, StatusCodes.Status400BadRequest,
				"Error en los datos de entrada.", builder.ToString());
		}
	}
}
