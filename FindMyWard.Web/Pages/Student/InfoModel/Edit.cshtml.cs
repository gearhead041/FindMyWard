using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FindMyWard.Models;
using FindMyWard.DataAccess.Repository.IRepository;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace FindMyWard.Web.Pages.Student.InfoModels;

[Authorize]
public class EditModel : PageModel
{
    private readonly IRepositoryManager _context;

    public EditModel(IRepositoryManager context)
    {
        _context = context;
    }

    [BindProperty]
    public StudentInfo StudentInfo { get; set; }

    public  IActionResult OnGetAsync(int? id)
    {
        if (id == null)
            return NotFound();

        var studentinfo =  _context.Students.GetFirstOrDefault(m => m.Id == id);
        var claimsIdentity = (ClaimsIdentity)User.Identity;
        var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
        if (studentinfo.UserId != claim.Value)
            return NotFound();

        StudentInfo = studentinfo;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        _context.Students.Update(StudentInfo);
        await _context.Save();
        return RedirectToPage("../Index");
    }
}
