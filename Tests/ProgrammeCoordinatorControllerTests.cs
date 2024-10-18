using Microsoft.AspNetCore.Mvc;
using PROG6212_POE.Controllers;
using PROG6212_POE.Models;
using Xunit;

namespace PROG6212_POE.Tests;

public class ProgrammeCoordinatorControllerTests
{
    [Fact]
    public void ApproveClaim_ValidClaimId_UpdatesClaimStatusAndRedirectsToDashboard()
    {
        // Arrange
        var controller = new ProgrammeCoordinatorController();
        var claimId = 1;
        LecturerController.claims.Add(new Claim { ClaimID = claimId, Status = "Pending" });

        // Act
        var result = controller.ApproveClaim(claimId) as RedirectToActionResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Dashboard", result.ActionName);
        Assert.Equal("Approved", LecturerController.claims.First(c => c.ClaimID == claimId).Status);
    }

    [Fact]
    public void RejectClaim_ValidClaimId_UpdatesClaimStatusAndRedirectsToDashboard()
    {
        // Arrange
        var controller = new ProgrammeCoordinatorController();
        var claimId = 2;
        LecturerController.claims.Add(new Claim { ClaimID = claimId, Status = "Pending" });

        // Act
        var result = controller.RejectClaim(claimId) as RedirectToActionResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Dashboard", result.ActionName);
        Assert.Equal("Rejected", LecturerController.claims.First(c => c.ClaimID == claimId).Status);
    }
}