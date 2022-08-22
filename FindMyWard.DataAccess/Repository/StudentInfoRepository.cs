
using FindMyWard.DataAccess.Data;
using FindMyWard.DataAccess.Repository.IRepository;
using FindMyWard.Models;

namespace FindMyWard.DataAccess.Repository;

public class StudentInfoRepository : Repository<StudentInfo>, IStudentInfoRepository
{
    private readonly ApplicationDbContext _context;
    public StudentInfoRepository(ApplicationDbContext context) 
        : base(context)
    {
        this._context = context;
    }

    public void Update(StudentInfo studentInfo)
    { 
        _context.Update<StudentInfo>(studentInfo);
    }
}
