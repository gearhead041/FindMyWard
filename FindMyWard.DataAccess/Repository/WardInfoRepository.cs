using FindMyWard.DataAccess.Data;
using FindMyWard.DataAccess.Repository.IRepository;
using FindMyWard.Models;

namespace FindMyWard.DataAccess.Repository;

public class WardInfoRepository : Repository<WardInfo>, IWardInfoRepository
{
    private readonly ApplicationDbContext _context;
    public WardInfoRepository(ApplicationDbContext context) : base(context)
    {
        this._context = context;
    }

    public void Update(WardInfo wardInfo)
    {
        var wardInfoFromDb = _context.Wards.FirstOrDefault(w => w.Id == wardInfo.Id);
        wardInfoFromDb.Email = wardInfo.Email;
        wardInfoFromDb.PhoneNumber = wardInfo.PhoneNumber;
        
    }
}
