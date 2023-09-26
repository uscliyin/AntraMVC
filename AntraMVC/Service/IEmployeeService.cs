using AntraMVC.Models.Domain;

namespace AntraMVC.Service
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<bool> AddOneEmployee(Employee obj);
        Task<Employee> GetOneEmployee(int id);
        Task<bool> DeleteOneEmployee(int id);
        Task<bool> UpdateEmployee(Employee obj);

    }
}
