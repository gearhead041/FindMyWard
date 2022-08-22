
using MailKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;

namespace FindMyWard.Utility;

public class EmailService : IEmailSender
{
    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {   

        var emailToSend = new MimeMessage();
        emailToSend.From.Add( new MailboxAddress("Service Account",SD.AdminMail));
        emailToSend.To.Add(new MailboxAddress("First Last",email));
        emailToSend.Subject = subject;
        emailToSend.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = htmlMessage };
        using (var emailClient = new SmtpClient(new ProtocolLogger("smtp.txt")))
        {
            //TODO also change this to be gmail
            await emailClient.ConnectAsync(SD.MicrosoftSmtp, 587, SecureSocketOptions.StartTls);
            //emailClient.AuthenticationMechanisms.Add("XOAUTH2");
            // TODO Make this more sensible use something that will be set when sending a message
            emailClient.Authenticate(SD.AdminMail, "Jibolatolu37#");
            await emailClient.SendAsync(emailToSend);
            emailClient.Disconnect(true);
        }

        return;
    }
}
