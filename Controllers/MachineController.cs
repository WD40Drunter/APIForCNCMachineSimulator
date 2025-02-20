namespace CNCWebAPI.Controllers
{
    using CNCWebAPI.Data;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using Models;

    [Route("api/machine")]
    [ApiController]
    public class MachineController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MachineController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetMachines()
        {
            return Ok(_context.Machines.ToList());
        }

        [HttpPost]
        public IActionResult AddMachine([FromBody] Machine machine)
        {
            _context.Machines.Add(machine);
            _context.SaveChanges();
            return Ok(machine);
        }
    }

}
