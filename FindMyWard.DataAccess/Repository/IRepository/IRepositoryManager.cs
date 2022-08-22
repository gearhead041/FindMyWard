
namespace FindMyWard.DataAccess.Repository.IRepository;

public interface IRepositoryManager : IDisposable
{
    IStudentInfoRepository Students { get; }
    IWardInfoRepository Wards { get; }
    ILocationRepository Locations { get; }
    IEventRepository Events { get; }
    INotificationRepository Notifications { get; }
    Task Save();
}
