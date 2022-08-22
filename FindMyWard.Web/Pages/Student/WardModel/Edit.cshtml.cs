using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FindMyWard.Models;
using FindMyWard.DataAccess.Repository.IRepository;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace FindMyWard.Web.Pages.Student.WardModel;

[Authorize]
public class EditModel : PageModel
{
    private readonly IRepositoryManager _context;

    public EditModel(IRepositoryManager context)
    {
        _context = context;
    }

    [BindProperty]
    public WardInfo WardInfo { get; set; }

    public  IActionResult OnGetAsync(int? id)
    {
        if (id == null)
            return NotFound();

        var wardInfo =  _context.Wards.GetFirstOrDefault(m => m.Id == id,includeProperties:"StudentInfo");
        var claimsIdentity = (ClaimsIdentity)User.Identity;
        var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

        if (wardInfo.StudentInfo.UserId != claim.Value)
            return NotFound();

        WardInfo = wardInfo;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        _context.Wards.Update(WardInfo);
        await _context.Save();
        return RedirectToPage("../Index");
    }
}
