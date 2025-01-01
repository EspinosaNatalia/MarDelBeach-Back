using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tesisv2_back.Data;
using tesisv2_back.Models;

namespace tesisv2_back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActividadesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ActividadesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Actividades
        [HttpGet]
        public async Task<IActionResult> GetActividades()
        {
            var actividades = await _context.Actividad.ToListAsync(); // Cambiado a singular y async
            return Ok(actividades);
        }

        // GET: api/Actividades/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetActividadById(int id)
        {
            var actividad = await _context.Actividad.FindAsync(id); // Cambiado a singular y async
            if (actividad == null)
            {
                return NotFound();
            }
            return Ok(actividad);
        }

        // POST: api/Actividades
        [HttpPost]
        public async Task<IActionResult> CreateActividad([FromBody] Actividad nuevaActividad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Actividad.Add(nuevaActividad); // Cambiado a singular
            await _context.SaveChangesAsync(); // Cambiado a async
            return CreatedAtAction(nameof(GetActividadById), new { id = nuevaActividad.Id }, nuevaActividad);
        }

        // PUT: api/Actividades/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActividad(int id, [FromBody] Actividad actividadActualizada)
        {
            if (id != actividadActualizada.Id)
            {
                return BadRequest();
            }

            var actividad = await _context.Actividad.FindAsync(id); // Cambiado a singular y async
            if (actividad == null)
            {
                return NotFound();
            }

            // Actualiza las propiedades
            actividad.Nombre = actividadActualizada.Nombre;
            actividad.Descripcion = actividadActualizada.Descripcion;
            actividad.Imagen = actividadActualizada.Imagen;
            actividad.Direccion = actividadActualizada.Direccion;
            actividad.Zona = actividadActualizada.Zona;
            actividad.Caracteristicas = actividadActualizada.Caracteristicas;
            actividad.Servicios = actividadActualizada.Servicios;
            actividad.Accesos = actividadActualizada.Accesos;
            actividad.PromedioValoracion = actividadActualizada.PromedioValoracion;

            await _context.SaveChangesAsync(); // Cambiado a async
            return NoContent();
        }

        // DELETE: api/Actividades/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActividad(int id)
        {
            var actividad = await _context.Actividad.FindAsync(id); // Cambiado a singular y async
            if (actividad == null)
            {
                return NotFound();
            }

            _context.Actividad.Remove(actividad); // Cambiado a singular
            await _context.SaveChangesAsync(); // Cambiado a async
            return NoContent();
        }
    }
}
