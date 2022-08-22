
using FindMyWard.Models;

namespace FindMyWard.Utility.IUtility;

public interface IAdmin
{
    void NotifyAllWithSMS(Notification notification);

    void AddEvent();

    void RemoveEvent();

    Task NotifyAllWithEmail(Notification notification);

    Task NofityWithEmailAsync(StudentInfo studentInfo, Notification notification);

}
