using UM.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace UM.Api.SeedWork.CustomProblemDetails
{
    public class BusinessRuleValidationProblemDetails : ProblemDetails
    {
        public List<string> Errors { get; }

        public BusinessRuleValidationProblemDetails(BusinessRuleValidationException exception, string traceId)
        {
            Title = "Business rule validation error";
            Status = StatusCodes.Status400BadRequest;
            Type = "https://httpstatuses.com/400";
            Errors = exception.Errors;
            Instance = traceId;
        }
    }
}
