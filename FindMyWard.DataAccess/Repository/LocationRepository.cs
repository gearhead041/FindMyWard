
using FindMyWard.DataAccess.Data;
using FindMyWard.DataAccess.Repository.IRepository;
using FindMyWard.Models;

namespace FindMyWard.DataAccess.Repository;

public class LocationRepository : Repository<Location>, ILocationRepository
{
    private readonly ApplicationDbContext _context;
    public LocationRepository(ApplicationDbContext context) 
        : base(context)
    {
        this._context = context;
    }

    public void Update(Location location)
    { 
        _context.Update<Location>(location);
    }
}
