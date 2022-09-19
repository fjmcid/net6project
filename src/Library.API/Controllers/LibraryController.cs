using System.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;

[Route("[controller]")]
public class LibraryController : Controller
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok();
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok();
    }
}