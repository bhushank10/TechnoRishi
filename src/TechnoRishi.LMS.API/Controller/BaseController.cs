using Carter;

namespace TechnoRishi.LMS.API.Controller
{
    public abstract class BaseController : CarterModule
    {
        public BaseController(string path) : base($"/api/{path}")
        {
        }
        public abstract override void AddRoutes(IEndpointRouteBuilder app);

    }
}