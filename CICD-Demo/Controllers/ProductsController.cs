using Microsoft.AspNetCore.Mvc;

namespace CICD_Demo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase {
    [HttpGet("{id}")]
    public IActionResult GetProduct(int id)
    {
        if (id <= 0) return BadRequest("Invalid ID");
        if (id > 100) return NotFound();

        return Ok(new { Id = id, Name = $"Product {id}" });
    }
}