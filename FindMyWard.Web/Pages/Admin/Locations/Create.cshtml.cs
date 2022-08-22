using FindMyWard.DataAccess.Repository.IRepository;
using FindMyWard.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FindMyWard.Web.Pages.Admin.Locations;

[Authorize]
public class CreateModel : PageModel
{
    private readonly IRepositoryManager _context;

    [BindProperty]
     public Location Location { get; set; }

    public CreateModel(IRepositoryManager context)
    {
        _context = context;
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost()
    {
        _context.Locations.Add(Location);
        await _context.Save();

        return RedirectToPage("Index");
    }
}
