using Microsoft.AspNetCore.Mvc.RazorPages;
using FindMyWard.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FindMyWard.Utility.IUtility;
using FindMyWard.Models;

namespace FindMyWard.Web.Pages.Admin;

[Authorize]
public class IndexModel : PageModel
{
    private readonly IRepositoryManager _context;

    private readonly IAdmin adminActions;

    [BindProperty]
    public Notification Notification { get; set; }
    public IndexModel(IRepositoryManager context, IAdmin adminActions)
    {
        _context = context;
        this.adminActions = adminActions;
    }


    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostNotifyAll()
    {
        await adminActions.NotifyAllWithEmail(Notification);

        return Page();
    }
}
