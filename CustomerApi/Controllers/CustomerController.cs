using CustomerApi.Data;
using CustomerApi.DTOs;
using CustomerApi.Models;
using CustomerApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections;
using System.Text.RegularExpressions;

namespace CustomerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        //Retrieve all Customers
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _customerService.GetAllCustomersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        //Update a Customer's details
        [HttpPut]
        public async Task<IActionResult> Update(string id, CustomerDTO customerDto)
        {
            if (customerDto == null)
            {
                return BadRequest();
            }

            var updatedUser = await _customerService.UpdateCustomerAsync(id, customerDto);

            if (updatedUser == null)
            {
                return NotFound();
            }

            return Ok(updatedUser);
        }

        //Add a new Cusomer
        [HttpPost]
        public async Task<IActionResult> Post(CustomerDTO customerDTO)
        {
            var createdCustomer = await _customerService.CreateCustomerAsync(customerDTO);
            return CreatedAtAction(nameof(GetById), new { id = createdCustomer.Id }, createdCustomer);
        }

        //Delete a Cusomer
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            var deletedCustomer = await _customerService.DeleteCustomerAsync(customer);
            return Ok();
        }

    }
}
