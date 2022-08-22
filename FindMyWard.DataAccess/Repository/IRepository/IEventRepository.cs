using FindMyWard.Models;

namespace FindMyWard.DataAccess.Repository.IRepository;

public interface IEventRepository : IRepositoryBase<Event>
{
    void Update(Event eventToUpdate);
}
