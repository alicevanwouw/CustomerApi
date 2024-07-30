using CustomerApi.Data;
using CustomerApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Text.RegularExpressions;

namespace CustomerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private CustomerContext _context;

        public CustomerController(CustomerContext context)
        {
            _context = context;
        }

        //Retrieve all Customers
        [HttpGet]
        public IActionResult Get()
        {
            return Json(_context.Customer.ToList());
        }

        //Update a Customer's details
        [HttpPut]
        public async Task<IActionResult> Put(string id, string values)
        {
            var customer = await _context.Customer
                .FirstOrDefaultAsync(u => u.Id.Equals(Guid.Parse(id)));

            if (customer == null)
                return StatusCode(409, "Customer not found");

            await _context.SaveChangesAsync();
            return Ok();

        }

        //Add a new Cusomer
        [HttpPost]
        public async Task<IActionResult> Post(string values)
        {
            var customer = new Customer();
            customer.Id = Guid.NewGuid();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateCustomerModel(customer, valuesDict);

            var result = _context.Customer.Add(customer);
            var newId = result.Entity.Id;
            await _context.SaveChangesAsync();

            return Json(newId);
        }

        private void PopulateCustomerModel(Customer model, IDictionary values)
        {
            string ID = nameof(Models.Customer.Id);
            string FIRST_NAME = nameof(Models.Customer.FirstName);
            string SURNAME = nameof(Models.Customer.Surname);
            string CELL_NUMBER = nameof(Models.Customer.CellNumber);
            string PHYSICAL_ADDRESS = nameof(Models.Customer.PhysicalAddress);
            string POSTAL_ADDRESS = nameof(Models.Customer.PostalAddress);

            if (values.Contains(ID))
            {
                model.Id = Guid.Parse(values[ID].ToString());
            }

            if (values.Contains(FIRST_NAME))
            {
                model.FirstName = Convert.ToString(values[FIRST_NAME]);
            }

            if (values.Contains(SURNAME))
            {
                model.Surname = Convert.ToString(values[SURNAME]);
            }

            if (values.Contains(CELL_NUMBER))
            {
                model.CellNumber = Convert.ToString(values[CELL_NUMBER]);
            }

            if (values.Contains(PHYSICAL_ADDRESS))
            {
                model.PhysicalAddress = Convert.ToString(values[PHYSICAL_ADDRESS]);
            }

            if (values.Contains(POSTAL_ADDRESS))
            {
                model.PhysicalAddress = Convert.ToString(values[POSTAL_ADDRESS]);
            }
        }
    }
}
