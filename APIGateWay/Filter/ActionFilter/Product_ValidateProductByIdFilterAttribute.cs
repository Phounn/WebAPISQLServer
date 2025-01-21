using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;

namespace APIGateWay.Filter.ActionFilter
{
    public class Product_ValidateProductByIdFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var ProductId = context.ActionArguments["id"] as int?;
            if (ProductId.HasValue)
            {
                if (ProductId.Value <= 0)
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
