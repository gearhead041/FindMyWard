using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FindMyWard.Models;

public class StudentInfo
{
    public int Id { get; set; }

    public string UserId { get; set; }

    [ValidateNever]
    [ForeignKey("UserId")]
    public IdentityUser User { get; set; }

    [Required(ErrorMessage ="Matric Number is Required.")]
    public string MatricNumber { get; set; }

    public string Name { get; set;}

    public string Gender { get; set; }

    public int? LocationId { get; set; }

    [Display(Name ="Location Assigned")]
    public Location? Location { get; set; }

    [ValidateNever]
    public ICollection<WardInfo> Wards { get; set; }
}