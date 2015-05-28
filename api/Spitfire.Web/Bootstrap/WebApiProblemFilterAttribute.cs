namespace Spitfire.Web.Bootstrap
{
    using System.Data.Entity.Infrastructure;
    using System.Net;
    using System.Web.Http.Filters;
    using WebApiProblem;

    public class WebApiProblemFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            var optimisticLockingProblem = context.Exception as DbUpdateConcurrencyException;
            if (optimisticLockingProblem != null)
            {
                context.Exception =
                    new BasicApiProblemException(
                        HttpStatusCode.Conflict,
                        "errors.concurrency",
                        string.Empty,
                        optimisticLockingProblem.Message);
            }
        }
    }
}