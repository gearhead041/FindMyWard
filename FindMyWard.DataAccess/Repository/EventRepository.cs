
using FindMyWard.DataAccess.Data;
using FindMyWard.DataAccess.Repository.IRepository;
using FindMyWard.Models;

namespace FindMyWard.DataAccess.Repository;

public class EventRepository : Repository<Event>, IEventRepository
{
    private readonly ApplicationDbContext _context;
    public EventRepository(ApplicationDbContext context) 
        : base(context)
    {
        this._context = context;
    }

    public void Update(Event eventToUpdate)
    { 
        _context.Update<Event>(eventToUpdate);
    }
}
