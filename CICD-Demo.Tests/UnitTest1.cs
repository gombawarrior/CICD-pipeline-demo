using CICD_Demo;
using CICD_Demo.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit;

namespace CICD_Demo.Tests;

[TestFixture]
public class ProductsControllerTests {
    private ProductsController _controller;

    [SetUp]
    public void SetUp() {
        _controller = new ProductsController();
    }

    [Test]
    [TestCase(-10)]
    [TestCase(0)]
    public void GetProduct_ReturnsBadRequest_WhenIdIsLessThanOrZero(int id)
    {
        // Act
        var result = _controller.GetProduct(id);

        // Assert
        Assert.That(result, Is.TypeOf<BadRequestObjectResult>());
        
        var badRequest = (BadRequestObjectResult)result;
        Assert.That(badRequest.Value, Is.EqualTo("Invalid ID"));
    }

    [Test]
    [TestCase(2)]
    public void GetProduct_ReturnsOk_WhenIdIsValid(int id)
    {
        // Act
        var result = _controller.GetProduct(1);

        // Assert
        Assert.That(result, Is.TypeOf<OkObjectResult>());
        
        var okObjectResult = (OkObjectResult)result;
        Assert.That(okObjectResult.Value, Is.Not.Null);
    }
    
    [Test]
    [TestCase(200)]
    public void GetProduct_WhenIdIsTooHigh_ReturnsNotFound(int id)
    {
        // Act
        var result = _controller.GetProduct(id);

        // Assert
        Assert.That(result, Is.TypeOf<NotFoundResult>());
    }
}