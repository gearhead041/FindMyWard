using FindMyWard.DataAccess.Repository.IRepository;
using FindMyWard.Models;
using FindMyWard.Utility.IUtility;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Diagnostics;
using Twilio;

namespace FindMyWard.Utility;

public class Admin : IAdmin
{
    private readonly IRepositoryManager _context;

    private readonly SMSService smsService;

    private readonly IEmailSender emailService;

    public Admin(IRepositoryManager context, IEmailSender emailSender)
    {
        _context = context;
        smsService = new SMSService();
        emailService =new EmailService();
    }
    public void AddEvent()
    {
        throw new NotImplementedException();
    }

    public async Task NofityWithEmailAsync(StudentInfo studentInfo, Notification notification)
    {
        var studentInfoFromDb = _context.Students.GetFirstOrDefault(s => s.Id == studentInfo.Id,
            includeProperties: "Wards");

        if (studentInfoFromDb == null)
            throw new Exception("Wards do not exist!");

        foreach (var ward in studentInfoFromDb.Wards)
        {
            //replace the word 'ward_name' with ward's name
            notification.Message = notification.Message.Replace(SD.StudentTempName, studentInfo.Name);
            await emailService.SendEmailAsync(ward.Email,notification.Subject, notification.Message);
        }
    }

    

    public async Task NotifyAllWithEmail(Notification notification)
    {
        foreach (var student in _context.Students.GetAll(includeProperties:"Wards"))
        {
            await NofityWithEmailAsync(student, notification);
        }
    }

    public void NotifyAllWithSMS(Notification notification)
    {
        TwilioClient.Init(
            Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID"),
            Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN"));
        foreach (var student in _context.Students.GetAll(includeProperties:"Wards"))
        {
            if (student.Wards != null)
            {
                foreach (var ward in student.Wards)
                {
                    try
                    {
                        smsService.SendSMS(notification.Message, ward.PhoneNumber);
                    }
                    catch (Exception ex)
                    {

                        Trace.WriteLine(ex.ToString());
                    }
                }
            }
        }
    }

    public void RemoveEvent()
    {
        throw new NotImplementedException();
    }
}
