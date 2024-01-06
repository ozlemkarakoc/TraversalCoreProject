using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Controllers
{
    public class LayoutPartialController : Controller
    {
        public PartialViewResult Index()
        {
            return PartialView();
        }
    }
}
