using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FindMyWard.Models;
using FindMyWard.DataAccess.Repository.IRepository;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace FindMyWard.Web.Pages.Student.InfoModels;

[Authorize]
public class CreateModel : PageModel
{
    private readonly  IRepositoryManager _context;

    [BindProperty]
    public StudentInfo StudentInfo { get; set; }
    
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

        StudentInfo.UserId = claims.Value;
        ModelState.ClearValidationState(nameof(StudentInfo));

        if (!TryValidateModel(StudentInfo, nameof(StudentInfo)))
        {
            return Page();
        }

        Location selectedLocation;

        var validLocations = _context.Locations.GetAll(l => l.GenderGroup == StudentInfo.Gender);

        try
        {
            selectedLocation = validLocations.OrderBy(l => l.Students.Count())
                    .FirstOrDefault();
        }
        catch (ArgumentNullException)
        {
            selectedLocation = validLocations.FirstOrDefault();
        }
            

        StudentInfo.LocationId = selectedLocation.Id;
        _context.Students.Add(StudentInfo);
        TempData["success"] = "Student Information Added";
        await _context.Save();

        return RedirectToPage("../Index");
    }
}
