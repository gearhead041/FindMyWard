using FindMyWard.DataAccess.Repository.IRepository;
using FindMyWard.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FindMyWard.Web.Pages.Admin.Student;

[Authorize]
[BindProperties]
public class DeleteModel : PageModel
{
    private readonly IRepositoryManager _context;

    public StudentInfo StudentInfo { get; set; }
    public DeleteModel(IRepositoryManager context)
    {
        _context = context;
    }

    public IActionResult OnGet(int? id)
    {
        if (id == null)
            return NotFound();
        StudentInfo = _context.Students.GetFirstOrDefault(s => s.Id == id, includeProperties: "Wards,User");
       
        return Page();
    }

    public async Task<IActionResult> OnPost()
    {
        _context.Students.Remove(StudentInfo);
        await _context.Save();

        return RedirectToPage("../Index");
    }
}
