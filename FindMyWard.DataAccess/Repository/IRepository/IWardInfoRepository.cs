using FindMyWard.Models;

namespace FindMyWard.DataAccess.Repository.IRepository;

public interface IWardInfoRepository : IRepositoryBase<WardInfo>
{
    public void Update(WardInfo wardInfo);
}
