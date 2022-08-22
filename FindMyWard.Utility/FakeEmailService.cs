using Microsoft.AspNetCore.Identity.UI.Services;

namespace FindMyWard.Utility;

public class FakeEmailService : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {   
        return Task.CompletedTask;
    }
}
