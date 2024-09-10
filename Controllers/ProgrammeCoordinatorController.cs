namespace PROG6212_POE.Controllers;

// Controllers/ProgrammeCoordinatorController.cs
using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class ProgrammeCoordinatorController : Controller
{
    public IActionResult ApproveClaims()
    {
        // Get pending claims
        var pendingClaims = LecturerController.claims.Where(c => c.Status == "Pending").ToList();
        return View(pendingClaims);
    }

    [HttpPost]
    public IActionResult ApproveClaim(int claimID, bool isApproved)
    {
        var claim = LecturerController.claims.FirstOrDefault(c => c.ClaimID == claimID);
        if (claim != null)
        {
            claim.Status = isApproved ? "Approved" : "Rejected";
        }

        return RedirectToAction("ApproveClaims");
    }
}
