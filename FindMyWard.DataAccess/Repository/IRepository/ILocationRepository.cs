using FindMyWard.Models;

namespace FindMyWard.DataAccess.Repository.IRepository;

public interface ILocationRepository: IRepositoryBase<Location>
{
    void Update(Location location);
}
