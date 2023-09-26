using AntraMVC.Data;
using AntraMVC.Models.Domain;

namespace AntraMVC.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AntraDbContext db) : base(db)
        {
        }
    }
}
