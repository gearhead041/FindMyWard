using FindMyWard.DataAccess.Repository.IRepository;
using FindMyWard.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FindMyWard.Web.Pages.Admin.Locations;

[Authorize]
public class EditModel : PageModel
{
    private readonly IRepositoryManager _context;

    [BindProperty]
     public Location Location { get; set; }

    public EditModel(IRepositoryManager context)
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

    public async Task<IActionResult> OnPost()
    {
        if (!ModelState.IsValid)
            return Page();

        _context.Locations.Update(Location);
        await _context.Save();

        return RedirectToPage("Index");
    }
}
