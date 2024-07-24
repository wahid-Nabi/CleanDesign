using Azure;
using CleanDesign.Application.Errors;
using CleanDesign.Domain.Errors;
using CleanDesign.Infrastructure.Exceptions;
using CleanDesign.Presentation.Errors;
using CleanDesign.SharedKernel;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Net;

namespace CleanDesign.Presentation.Exceptions
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;
        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.ToString());
                var error = HandleException(context, ex);

                await context.Response.WriteAsJsonAsync(error);
            }
        }

        public Error HandleException(HttpContext context, Exception exception)
        {
            Error error;
            switch (exception)
            {
                case EmailNotRegisteredException:
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    error = AuthValidationErrors.EmailNotRegistered;
                    break;
                case EmailNullException:
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    error = AuthValidationErrors.EmailNull;
                    break;
                    
                case ArgumentNullException:
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    error = Error.NullValue;
                    break;

                case ArgumentException:
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    error = Error.NullValue;
                    break;

                case SecurityTokenException:
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    error = GenericAuthErrors.InvalidToken;
                    break;

                default:
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    error = ApplicationErrors.InternalServerError;
                    break;
            }

            return error;
        }
    }
}
