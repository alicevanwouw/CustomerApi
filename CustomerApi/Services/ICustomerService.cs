using CustomerApi.DTOs;

namespace CustomerApi.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDTO>> GetAllCustomersAsync();
        Task<CustomerDTO> GetCustomerByIdAsync(string id);
        Task<CustomerDTO> CreateCustomerAsync(CustomerDTO customerDto);
        Task<CustomerDTO> UpdateCustomerAsync(string id, CustomerDTO customerDto);
        Task<CustomerDTO> DeleteCustomerAsync(CustomerDTO customerDto);
    }
}
