using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FindMyWard.Models;
using FindMyWard.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;

namespace FindMyWard.Web.Pages.Student.WardModel;

[Authorize]
public class DeleteModel : PageModel
{
    private readonly  IRepositoryManager _context;

    [BindProperty]
    public WardInfo WardInfo { get; set; }
    
    public DeleteModel(IRepositoryManager context)
    {
        _context = context;
    }

    public void OnGet(int id)
    {
        WardInfo = _context.Wards.GetById(id);
    }


    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPost()
    {
        var wardFromDb = _context.Wards.GetById(WardInfo.Id);
        if (wardFromDb != null)
        {
            _context.Wards.Remove(wardFromDb);
            await _context.Save();
            return RedirectToPage("../Index");
            TempData["success"] = "Ward Deleted";
        }

        return Page();
    }
}
