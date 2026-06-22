using ClientesAPI.Data;
using ClientesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClientesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        // GET: api/clientes/0001
        [HttpGet("{clave}")]
        public async Task<ActionResult<Cliente>> GetCliente(string clave)
        {
            var cliente = await _context.Clientes.FindAsync(clave);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        // POST: api/clientes
        [HttpPost]
        public async Task<ActionResult> CrearCliente(Cliente cliente)
        {
            var existe = await _context.Clientes.FindAsync(cliente.Clave);

            if (existe != null)
            {
                return BadRequest("La clave ya existe.");
            }

            cliente.FechaNacimiento = DateTime.SpecifyKind(
                cliente.FechaNacimiento,
                DateTimeKind.Utc
            );

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return Ok("Cliente guardado correctamente.");
        }

        // PUT: api/clientes/0001
        [HttpPut("{clave}")]
        public async Task<ActionResult> ActualizarCliente(string clave, Cliente cliente)
        {
            if (clave != cliente.Clave)
            {
                return BadRequest();
            }

            var existe = await _context.Clientes.FindAsync(clave);

            if (existe == null)
            {
                return NotFound();
            }

            cliente.FechaNacimiento = DateTime.SpecifyKind(
                cliente.FechaNacimiento,
                DateTimeKind.Utc
            );

            existe.Nombre = cliente.Nombre;
            existe.Edad = cliente.Edad;
            existe.FechaNacimiento = cliente.FechaNacimiento;

            await _context.SaveChangesAsync();

            return Ok("Cliente actualizado correctamente.");
        }

        // DELETE: api/clientes/0001
        [HttpDelete("{clave}")]
        public async Task<ActionResult> EliminarCliente(string clave)
        {
            var cliente = await _context.Clientes.FindAsync(clave);

            if (cliente == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return Ok("Cliente eliminado correctamente.");
        }
    }
}