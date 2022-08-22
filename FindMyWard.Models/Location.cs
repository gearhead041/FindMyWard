
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace FindMyWard.Models;

//Use GMap or not
public class Location
{
    public int Id { get; set; }

    [Display(Name ="Location Name")]
    public string Name { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public int Zoom { get; set; }

    [Display(Name="Short Description")]
    public string Description { get; set; }

    public string? ImageUrl { get; set; }

    [Display(Name ="Gender")]
    public string GenderGroup { get; set; }

    [ValidateNever]
    public ICollection<StudentInfo> Students { get; set; }
}
