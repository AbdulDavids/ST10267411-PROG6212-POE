using PROG6212_POE.Controllers;
using PROG6212_POE.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;


namespace PROG6212_POE.Tests;

public class LecturerControllerTests
{
    [Fact]
    public void SubmitClaim_ValidClaim_RedirectsToDashboard()
    {
        // Arrange
        var controller = new LecturerController();
        var claim = new Claim
        {
            LecturerName = "John Doe",
            HoursWorked = 10,
            AmountDue = 500,
            Description = "Test claim"
        };

        // Act
        var result = controller.SubmitClaim(claim) as RedirectToActionResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Dashboard", result.ActionName);
    }

    [Fact]
    public void Dashboard_ReturnsViewWithClaims()
    {
        // Arrange
        var controller = new LecturerController();

        // Act
        var result = controller.Dashboard() as ViewResult;

        // Assert
        Assert.NotNull(result);
        Assert.IsType<List<Claim>>(result.Model);
    }
}

