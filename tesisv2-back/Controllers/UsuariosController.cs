using Microsoft.AspNetCore.Mvc;
using tesisv2_back.Data;
using tesisv2_back.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace tesisv2_back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Registrar un usuario
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] Usuario usuario)
        {
            if (usuario == null || string.IsNullOrEmpty(usuario.UID))
                return BadRequest("Usuario inválido.");

            var existingUser = await _context.Usuario.FirstOrDefaultAsync(u => u.UID == usuario.UID);
            if (existingUser == null)
            {
                usuario.FechaRegistro = DateTime.Now;
                _context.Usuario.Add(usuario);
                await _context.SaveChangesAsync();
                return Ok("Usuario registrado correctamente.");
            }

            return Ok("El usuario ya está registrado.");
        }

        // Obtener información de un usuario por UID
        [HttpGet("{uid}")]
        public async Task<IActionResult> GetUser(string uid)
        {
            var usuario = await _context.Usuario.FirstOrDefaultAsync(u => u.UID == uid);

            if (usuario == null)
                return NotFound("Usuario no encontrado.");

            return Ok(usuario);
        }

        // Actualizar información de un usuario
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] Usuario usuario)
        {
            if (id != usuario.Id)
                return BadRequest("El ID del usuario no coincide.");

            var existingUser = await _context.Usuario.FindAsync(id);
            if (existingUser == null)
                return NotFound("Usuario no encontrado.");

            existingUser.Email = usuario.Email;
            existingUser.Nombre = usuario.Nombre;

            await _context.SaveChangesAsync();
            return Ok("Usuario actualizado correctamente.");
        }

        // Eliminar un usuario
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
                return NotFound("Usuario no encontrado.");

            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();
            return Ok("Usuario eliminado correctamente.");
        }
    }
}
