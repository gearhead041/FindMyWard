using FindMyWard.Models;

namespace FindMyWard.DataAccess.Repository.IRepository;

public interface INotificationRepository : IRepositoryBase<Notification>
{
    void Update(Notification notification);
}
