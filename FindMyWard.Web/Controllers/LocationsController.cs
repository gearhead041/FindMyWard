using FindMyWard.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FindMyWard.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class LocationsController : Controller
{
    private readonly IRepositoryManager _context;

    public LocationsController(IRepositoryManager context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var locations = _context.Locations.GetAll(includeProperties:"Students");

        return Json(new { data = locations});
    }


    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteLocation(int id)
    {
        var location = _context.Locations
           .GetFirstOrDefault(l => l.Id == id);
        if (location == null)
            return NotFound();

        _context.Locations.Remove(location);
        await _context.Save();

        return NoContent();
    }
}
