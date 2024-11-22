using Microsoft.AspNetCore.Mvc;
using PROG6212_POE.Models;
using PROG6212_POE.Controllers;

namespace PROG6212_POE.Controllers
{
    public class HumanResourcesController : Controller
    {
        public static HumanResources HR = new HumanResources();

        public IActionResult Dashboard()
        {
            var claims = LecturerController.claims; // Get claims from LecturerController
            return View(claims);
        }
    }
}