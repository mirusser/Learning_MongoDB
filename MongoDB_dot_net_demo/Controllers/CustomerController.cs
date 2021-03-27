using Microsoft.AspNetCore.Mvc;
using MongoDB_dot_net_demo.DBModels;
using MongoDB_dot_net_demo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDB_dot_net_demo.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _customerService.GetAllAsync());
        }

        [HttpGet("{id:length(24)}", Name = "Get")]
        public async Task<IActionResult> Get(string id)
        {
            var customer = await _customerService.GetByIdAsync(id);

            return customer != null ? Ok(customer) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> Create([FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _customerService.CreateAsync(customer);

            return CreatedAtRoute(nameof(Get), new { id = customer.Id}, customer);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, [FromBody] Customer customerIn)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if(customer == null)
            {
                return NotFound();
            }

            await _customerService.UpdateAsync(id, customerIn);
            return NoContent();
        }

        //there should be also patch action to update customer, but im to lazy right now to write one

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if(customer == null)
            {
                return NotFound();
            }

            await _customerService.DeleteAsync(customer.Id);
            return NoContent();
        }

    }
}
