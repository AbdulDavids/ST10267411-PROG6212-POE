// Controllers/LecturerController.cs
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using PROG6212_POE.Models;

namespace PROG6212_POE.Controllers
{



    public class LecturerController : Controller
    {
        public static List<Claim> claims = new List<Claim>(); // Simulate database

        // Display the dashboard for the lecturer
        public IActionResult Dashboard()
        {
            return View(claims);
        }

        // Submit a new claim
        public IActionResult SubmitClaim()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitClaim(Claim claim)
        {
            claim.Status = "Pending"; // Initially set the status to "Pending"
            claim.DateSubmitted = DateTime.Now;
            claims.Add(claim);
            return RedirectToAction("Dashboard");
        }

        // View claims submitted by the lecturer
        public IActionResult ViewClaims()
        {
            return View(claims);
        }

        // Placeholder for uploading documents
        public IActionResult UploadDocuments()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploadDocuments(int claimId)
        {
            // Placeholder for handling file uploads (this can be implemented later)
            return RedirectToAction("Dashboard");
        }

        // This action returns the list of claims for real-time status updates (For JavaScript Polling)
        [HttpGet]
        public JsonResult GetUpdatedClaims()
        {
            return Json(claims);
        }
    }
}