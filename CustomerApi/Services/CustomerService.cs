using AutoMapper;
using CustomerApi.DTOs;
using CustomerApi.Models;
using CustomerApi.Repositories;

namespace CustomerApi.Services
{
    public class CustomerService:ICustomerService
    {

        private readonly ICustomerRepository _customerRepository;

        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CustomerDTO> CreateCustomerAsync(CustomerDTO customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            await _customerRepository.AddAsync(customer);
            return _mapper.Map<CustomerDTO>(customer);
        }

        public async Task<CustomerDTO> DeleteCustomerAsync(CustomerDTO customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            await _customerRepository.DeleteAsync(customer);
            return _mapper.Map<CustomerDTO>(customer);
        }

        public async Task<IEnumerable<CustomerDTO>> GetAllCustomersAsync()
        {
            var customers = await _customerRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CustomerDTO>>(customers);
        }

        public async Task<CustomerDTO> GetCustomerByIdAsync(string id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            return _mapper.Map<CustomerDTO>(customer);
        }

        public async Task<CustomerDTO> UpdateCustomerAsync(string id, CustomerDTO customerDto)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
            {
                return null;
            }

            _mapper.Map(customerDto, customer);
            await _customerRepository.UpdateAsync(customer);
            return _mapper.Map<CustomerDTO>(customer);
        }
    }
}
