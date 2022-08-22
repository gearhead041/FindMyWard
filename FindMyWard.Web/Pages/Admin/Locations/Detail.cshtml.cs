using FindMyWard.DataAccess.Repository.IRepository;
using FindMyWard.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FindMyWard.Web.Pages.Admin.Locations;

[Authorize]
public class DetailModel : PageModel
{
    private readonly IRepositoryManager _context;

    [BindProperty]
     public Location Location { get; set; }

    public DetailModel(IRepositoryManager context)
    {
        _context = context;
    }

    public IActionResult OnGet(int id)
    {
        Location = _context.Locations.GetFirstOrDefault(l => l.Id == id);
        if (Location == null)
            return NotFound();

        return Page();
    }

    
}
