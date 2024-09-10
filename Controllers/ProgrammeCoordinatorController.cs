// Controllers/ProgrammeCoordinatorController.cs
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace PROG6212_POE.Controllers
{

    public class ProgrammeCoordinatorController : Controller
    {
        public IActionResult Dashboard()
        {
            var pendingClaims = LecturerController.claims.Where(c => c.Status == "Pending").ToList();
            return View(pendingClaims);
        }
        
        // This action should return a view with the list of pending claims to approve
        public IActionResult ApproveClaims()
        {
            var pendingClaims = LecturerController.claims.Where(c => c.Status == "Pending").ToList();
            return View(pendingClaims);
        }

        [HttpPost]
        public IActionResult ApproveClaim(int claimID)
        {
            var claim = LecturerController.claims.FirstOrDefault(c => c.ClaimID == claimID);
            if (claim != null)
            {
                claim.Status = "Approved";
            }

            return RedirectToAction("Dashboard");
        }

        [HttpPost]
        public IActionResult RejectClaim(int claimID)
        {
            var claim = LecturerController.claims.FirstOrDefault(c => c.ClaimID == claimID);
            if (claim != null)
            {
                claim.Status = "Rejected";
            }

            return RedirectToAction("Dashboard");
        }
    }
}