using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FindMyWard.Models;
using FindMyWard.DataAccess.Repository.IRepository;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace FindMyWard.Web.Pages.Student.WardModel;

[Authorize]
public class CreateModel : PageModel
{
    private readonly  IRepositoryManager _context;

    [BindProperty]
    public WardInfo WardInfo { get; set; }
    
    public CreateModel(IRepositoryManager context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }


    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        var claimsIdentity = (ClaimsIdentity)User.Identity;

        var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

        var studentInfo = _context.Students.GetFirstOrDefault(s => s.UserId == claims.Value);
        if (studentInfo == null)
            return NotFound();
        //studentInfo.Wards.Append(WardInfo);
        WardInfo.StudentInfoId = studentInfo.Id;
        if (!ModelState.IsValid)
            return Page();
        _context.Wards.Add(WardInfo);
        await _context.Save();
        studentInfo.Wards.Append(WardInfo);
        await _context.Save();
        TempData["success"] = "New Ward Created";

        return RedirectToPage("../Index");
    }
}
