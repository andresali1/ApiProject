using ApiProject.Models;

namespace ApiProject.Services
{
    public interface IService_Api
    {
        Task<List<Employee>> GetAll();
        Task<Employee> GetById(int id);
    }
}
