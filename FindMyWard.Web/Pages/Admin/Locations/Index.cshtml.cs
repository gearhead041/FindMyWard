using FindMyWard.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FindMyWard.Web.Pages.Admin.Locations;

[Authorize]
public class IndexModel : PageModel
{
    private readonly IRepositoryManager _context;

    public IndexModel(IRepositoryManager context)
    {
        _context = context;
    }

    public void OnGet()
    {
    }
}
