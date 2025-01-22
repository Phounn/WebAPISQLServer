using Microsoft.AspNetCore.Mvc.Filters;

namespace APIGateWay.Filter.ExceptionFilter
{
    public class Product_HandleUpdateExceptionsFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);
            var strProductId = context.RouteData.Values["id"] as string;
            if (int.TryParse(strProductId, out int productId))
            {
            }
        }
    }
}
