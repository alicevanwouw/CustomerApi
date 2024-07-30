using CustomerApi.Data;
using CustomerApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Text.RegularExpressions;

namespace CustomerApi.Repositories
{
    public class CustomerRepository:ICustomerRepository
    {

        private ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Customer customer)
        {
            await _context.Customer.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Customer customer)
        {
            var customerFound = await _context.Customer
               .FirstOrDefaultAsync(u => u.Id.Equals(customer.Id));

            _context.Customer.Remove(customer);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customer.ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(string id)
        {
            return await _context.Customer.FindAsync(id);
        }

        public async Task UpdateAsync(Customer customer)
        {
            _context.Customer.Update(customer);
            await _context.SaveChangesAsync();

        }
    }
}
