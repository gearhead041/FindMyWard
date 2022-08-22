using FindMyWard.Models;

namespace FindMyWard.DataAccess.Repository.IRepository;

public interface IStudentInfoRepository : IRepositoryBase<StudentInfo>
{
    void Update(StudentInfo studentInfo);
}
