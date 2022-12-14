using CustomerService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly DataContext _context;

        public CarController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Car>>> Get()
        {
            return Ok(await _context.Car.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> Get(int id)
        {
            var car = await _context.Car.FindAsync(id);
            if (car == null)
            {
                return BadRequest("Customer not found");
            }
            return Ok(car);
        }
        [HttpPost]
        public async Task<ActionResult<List<Car>>> AddCar(Car car)
        {
            _context.Car.Add(car);
            await _context.SaveChangesAsync();
            return Ok(await _context.Car.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<Car>>> UpdateCar(Car c)
        {
            var car = await _context.Car.FindAsync(c.Id);
            if (car == null)
            {
                return BadRequest("Customer not found");
            }
            car.Make = c.Make;
            car.Model = c.Model;
            car.YearMade = c.YearMade;

            await _context.SaveChangesAsync();

            return Ok(await _context.Car.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Car>> Delete(int id)
        {
            var car = await _context.Car.FindAsync(id);
            if (car == null)
            {
                return BadRequest("Car not found");
            }
            _context.Car.Remove(car);
            await _context.SaveChangesAsync();

            return Ok(await _context.Car.ToListAsync());
        }
    }
}
