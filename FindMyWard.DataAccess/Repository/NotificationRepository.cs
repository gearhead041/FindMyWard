
using FindMyWard.DataAccess.Data;
using FindMyWard.DataAccess.Repository.IRepository;
using FindMyWard.Models;

namespace FindMyWard.DataAccess.Repository;

public class NotificationRepository : Repository<Notification>, INotificationRepository
{
    private readonly ApplicationDbContext _context;
    public NotificationRepository(ApplicationDbContext context) 
        : base(context)
    {
        this._context = context;
    }

    public void Update(Notification notification)
    { 
        _context.Update<Notification>(notification);
    }
}
