using FindMyWard.DataAccess.Repository.IRepository;
using FindMyWard.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace FindMyWard.Web.Pages.Student;

[Authorize]
[BindProperties]
public class IndexModel : PageModel
{
    private readonly IRepositoryManager repositoryManager;

    public StudentInfo StudentInfo { get; set; }

    public IndexModel(IRepositoryManager repositoryManager)
    {
        this.repositoryManager = repositoryManager;
    }

    public void OnGet()
    {
        var claimsIdentity = (ClaimsIdentity)User.Identity;
        var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
         StudentInfo = repositoryManager.Students.GetFirstOrDefault(s => s.UserId == claim.Value, includeProperties:"Wards,User,Location");
        
    }
}
