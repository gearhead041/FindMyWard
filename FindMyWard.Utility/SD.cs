
namespace FindMyWard.Utility;
//TODO add roles on init check if exist if not seed db also fix registration and login

public static  class SD
{
    public const string AdminRole = "Admin";

    public const string MaleGroup = "Male";
    public const string FemaleGroup = "Female";

    public const string StudentTempName = "ward_name";

    //HACK preferably store in database
    public const string AdminMail = "";
    public const string AdminPassword = "";
    public const string GmailSmtp = "";
    public const string MicrosoftSmtp = "smtp-mail.outlook.com";
    public const string MailJetSmtp = "in.mailjet.com";
}
