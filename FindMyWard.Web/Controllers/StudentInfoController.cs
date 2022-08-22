using FindMyWard.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FindMyWard.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class StudentInfoController : Controller
{
    private readonly IRepositoryManager _context;

    public StudentInfoController(IRepositoryManager context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var students = _context.Students.GetAll(includeProperties:"User");
        return Json(new {data = students});
    }

    [Route("Location")]
    [HttpGet("{id:int}")]
    public IActionResult GetByLocation(int id)
    {
        var students = _context.Students.GetAll(s => s.LocationId == id, includeProperties:"User");

        return Json(new { data = students });
    }
}
