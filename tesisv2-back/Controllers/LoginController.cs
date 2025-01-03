﻿using Microsoft.AspNetCore.Mvc;
using tesisv2_back.Data;
using tesisv2_back.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace tesisv2_back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] Usuario usuario)
        {
            if (usuario == null || string.IsNullOrEmpty(usuario.UID))
                return BadRequest("Usuario inválido.");  // BadRequest (400)

            var existingUser = await _context.Usuario
                .FirstOrDefaultAsync(u => u.UID == usuario.UID);

            if (existingUser == null)
            {
                _context.Usuario.Add(usuario);
                await _context.SaveChangesAsync();
                Console.WriteLine($"Usuario registrado: {usuario.Email}");  // Log para ver en consola
                return Ok("Usuario registrado correctamente.");  // OK (200)
            }

            Console.WriteLine($"El usuario {usuario.Email} ya existe.");  // Log para ver en consola
            return Ok("El usuario ya está registrado.");  // OK (200)
        }

    }
}
