using FindMyWard.DataAccess.Repository.IRepository;
using FindMyWard.Models;
using FindMyWard.Utility.IUtility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FindMyWard.Web.Pages.Admin.Student;

[Authorize]
[BindProperties]
public class IndexModel : PageModel
{
    private readonly IRepositoryManager repositoryManager;

    private readonly IAdmin adminActions;

    public StudentInfo? StudentInfo { get; set; }

    public Notification Notification { get; set; }
    public IndexModel(IRepositoryManager repositoryManager, IAdmin admin)
    {
        this.repositoryManager = repositoryManager;
        this.adminActions = admin;
    }

    public void OnGet([FromQuery]int? id)
    {

        StudentInfo = repositoryManager.Students.GetFirstOrDefault(s => s.Id == id, includeProperties: "Wards,User,Location");
    }

    public IActionResult OnPost()
    {
        //HACK for some reason, sends only student id, fix later
        adminActions.NofityWithEmailAsync(StudentInfo, Notification);
        return RedirectToPage("../Index");
    }
}
