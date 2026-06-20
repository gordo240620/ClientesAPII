using ClientesAPI.Data;
using ClientesAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClientesAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;

    public AuthController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var usuario = await _context.Usuarios
            .FirstOrDefaultAsync(x =>
                x.UsuarioNombre == request.Usuario &&
                x.Password == request.Password);

        if (usuario == null)
        {
            return Unauthorized(new
            {
                mensaje = "Usuario o contraseña incorrectos"
            });
        }

        return Ok(new
        {
            mensaje = "Acceso correcto",
            usuario = usuario.UsuarioNombre
        });
    }
}