using AntraMVC.Models.Domain;
using AntraMVC.Repository;

namespace AntraMVC.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repo;
        public EmployeeService(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> AddOneEmployee(Employee obj)
        {
            await _repo.AddAsync(obj);
            return true;
        }

        public async Task<bool> DeleteOneEmployee(int id )
        {
            await _repo.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            var employeeLists = await _repo.GetAllAsync();
            return employeeLists;
        }

        public async Task<Employee> GetOneEmployee(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<bool> UpdateEmployee(Employee obj)
        {
            await _repo.UpdateAsync(obj);
            return true;
        }
    }
}
