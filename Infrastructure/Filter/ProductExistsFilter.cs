using Microsoft.AspNetCore.Mvc.Filters;
using ProductCatalog.Domain.CustomeException;

namespace ProductCatalog.Infrastructure.Filter
{
    public class ProductExistsFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionArguments.TryGetValue("ProductID", out var ProductID_Obj) && ProductID_Obj is long ProductID)
                if (ProductID <= 0) throw new ProductNotFoundCustomeException();
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
