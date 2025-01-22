using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;

namespace APIGateWay.Filter.ActionFilter
{
    public class Id_ValidateFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var Id = context.ActionArguments["id"] as int?;
            if (Id.HasValue)
            {
                if (Id.Value <= 0)
                {
                    context.ModelState.AddModelError("Id", "Product Id is Invalid");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }
            }
        }
    }
}
