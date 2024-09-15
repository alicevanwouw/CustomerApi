using CustomerApi.Models;

namespace CustomerApi.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(string id);
        Task AddAsync(Customer customer);
        Task DeleteAsync(Customer customer);
        Task UpdateAsync(Customer customer);

    }
}
