using CustomerService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly DataContext _context;

        public CustomerController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> Get()
        {
            return Ok(await _context.Customers.Select(c => new Customer()
            {
                Id = c.Id,
                Name = c.Name,
                SurName = c.SurName,
                FamilyName = c.FamilyName,
                CarId = c.CarId,
                Car = c.Car
            }).ToListAsync());

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> Get(int id)
        {
            var customer = await _context.Customers.Where(c => c.Id == id).Select(c => new Customer()
            {
                Id = c.Id,
                Name = c.Name,
                SurName = c.SurName,
                FamilyName = c.FamilyName,
                CarId = c.CarId,
                Car = c.Car
            }).ToListAsync();
            if (customer == null)
            {
                return BadRequest("Customer not found");
            }
            return Ok(customer);
        }
        [HttpPost]
        public async Task<ActionResult<List<Customer>>> AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return Ok(await _context.Customers.Select(c => new Customer()
            {
                Id = c.Id,
                Name = c.Name,
                SurName = c.SurName,
                FamilyName = c.FamilyName,
                CarId = c.CarId,
                Car = c.Car
            }).ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<Customer>>> UpdateCustomer(Customer c)
        {
            var customer = await _context.Customers.FindAsync(c.Id);
            if (customer == null)
            {
                return BadRequest("Customer not found");
            }
            customer.Name = c.Name;
            customer.SurName = c.SurName;
            customer.FamilyName = c.FamilyName;
            customer.CarId = c.CarId;

            await _context.SaveChangesAsync();

            return Ok(await _context.Customers.Select(c => new Customer()
            {
                Id = c.Id,
                Name = c.Name,
                SurName = c.SurName,
                FamilyName = c.FamilyName,
                CarId = c.CarId,
                Car = c.Car
            }).ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> Delete(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return BadRequest("Car not found");
            }
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return Ok(await _context.Customers.Select(c => new Customer()
            {
                Id = c.Id,
                Name = c.Name,
                SurName = c.SurName,
                FamilyName = c.FamilyName,
                CarId = c.CarId,
                Car = c.Car
            }).ToListAsync()); ;
        }
    }
}
