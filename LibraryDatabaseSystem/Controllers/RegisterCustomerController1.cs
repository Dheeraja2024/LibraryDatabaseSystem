using Microsoft.AspNetCore.Mvc;

namespace LibraryDatabaseSystem.Controllers
{
    public class RegisterCustomerController1 : Controller
    {
        public IActionResult Index_Pageload()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register_click()
        {

        }

    }
}
