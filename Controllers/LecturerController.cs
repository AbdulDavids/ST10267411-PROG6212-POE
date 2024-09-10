using PROG6212_POE.Models;

namespace PROG6212_POE.Controllers;


// Controllers/LecturerController.cs
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

public class LecturerController : Controller
{
    public static List<Claim> claims = new List<Claim>();

    public IActionResult SubmitClaim()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SubmitClaim(Claim claim)
    {
        // For now, we'll set the claim status to "Pending"
        claim.Status = "Pending";
        claims.Add(claim);
        return RedirectToAction("ViewClaims");
    }

    public IActionResult ViewClaims()
    {
        // View submitted claims
        return View(claims);
    }
}
