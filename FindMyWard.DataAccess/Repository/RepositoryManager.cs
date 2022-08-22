
using FindMyWard.DataAccess.Data;
using FindMyWard.DataAccess.Repository.IRepository;

namespace FindMyWard.DataAccess.Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly ApplicationDbContext _context;
    private readonly Lazy<IStudentInfoRepository> studentInfoRepository;
    private readonly Lazy<IWardInfoRepository> wardInfoRepository;
    private readonly Lazy<ILocationRepository> locationRepository;
    private readonly Lazy<IEventRepository> eventRepository;
    private readonly Lazy<INotificationRepository> notificationRepository;

    public RepositoryManager(ApplicationDbContext context)
    {
        _context = context;

        studentInfoRepository= new Lazy<IStudentInfoRepository>(()
            => new StudentInfoRepository(context));

        wardInfoRepository = new Lazy<IWardInfoRepository>(()
            => new WardInfoRepository(context));

        locationRepository = new Lazy<ILocationRepository>(() 
            => new LocationRepository(context));

        eventRepository = new Lazy<IEventRepository>(()
            => new EventRepository(context));

        notificationRepository = new Lazy<INotificationRepository>(()
            => new NotificationRepository(context));
    }

    public IStudentInfoRepository Students => studentInfoRepository.Value;
    public ILocationRepository Locations => locationRepository.Value;
    public IWardInfoRepository Wards => wardInfoRepository.Value;
    public IEventRepository Events => eventRepository.Value;
    public INotificationRepository Notifications => notificationRepository.Value;    

    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}
