
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace FindMyWard.Models;

public class WardInfo
{
    public int Id { get; set; }

    public string PhoneNumber { get; set; }

    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    public int StudentInfoId { get; set; }

    [ValidateNever]
    public StudentInfo StudentInfo { get; set; }
}
