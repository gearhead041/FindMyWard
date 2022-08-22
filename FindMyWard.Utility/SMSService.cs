
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace FindMyWard.Utility;
//TODO check out SMS service
public class SMSService
{
    public SMSService()
    {
        var username = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
        var password = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");

        TwilioClient.Init(username, password);
    }

    public void SendSMS(string message, string phoneNumber)
    {
        MessageResource.Create(
                        to: new PhoneNumber(phoneNumber),
                    from: new PhoneNumber("+19162492072"),
                    body: message);
    }
}
