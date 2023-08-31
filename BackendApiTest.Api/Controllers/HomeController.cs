using Microsoft.AspNetCore.Mvc;

namespace BackendApiTest.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => Redirect("/swagger");
    }
}