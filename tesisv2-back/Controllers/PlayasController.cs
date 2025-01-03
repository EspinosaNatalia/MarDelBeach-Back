using Microsoft.AspNetCore.Mvc;
using tesisv2_back.Data;
using tesisv2_back.Models;
using System.Linq;

namespace tesisv2_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PlayasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Playas
        [HttpGet]
        public IActionResult GetPlayas()
        {
            var playas = _context.Playa.ToList(); // Obtiene todas las playas
            return Ok(playas);
        }

        // GET: api/Playas/{id}
        [HttpGet("{id}")]
        public IActionResult GetPlaya(int id)
        {
            var playa = _context.Playa.Find(id); // Busca una playa por su ID
            if (playa == null)
            {
                return NotFound();
            }

            // Convertir cadenas separadas por comas en listas
            var response = new
            {
                playa.Id,
                playa.Nombre,
                playa.Direccion,
                playa.Capacidad,
                playa.Zona,
                Imagenes = playa.Imagenes.Split(','), // Convierte las imágenes a lista
                Caracteristicas = playa.Caracteristicas.Split(','), // Lista de características
                Servicios = playa.Servicios.Split(','), // Lista de servicios
                Accesos = playa.Accesos.Split(','), // Lista de accesos
                playa.PromedioValoracion
            };

            return Ok(response); // Devuelve los datos de la playa en formato JSON
        }
        [HttpPost("filtrar")]
        public IActionResult FiltrarPlayas([FromBody] Filtro filtros)
        {
            var query = _context.Playa.AsQueryable();

            // Verifica si se ha pasado una zona para filtrar
            if (!string.IsNullOrEmpty(filtros.Zona))
            {
                query = query.Where(p => p.Zona == filtros.Zona); // Filtra las playas por zona
            }

            // Filtra por capacidad si está marcado como true
            if (filtros.Capacidad)
            {
                query = query.Where(p => p.Capacidad >= 100 && p.Capacidad <= 500);
            }

            var playasFiltradas = query.ToList();
            return Ok(playasFiltradas); // Devuelve las playas filtradas
        }


        // POST: api/Playas
        [HttpPost]
        public IActionResult CreatePlaya([FromBody] Playa nuevaPlaya)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Playa.Add(nuevaPlaya); // Agrega una nueva playa
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetPlaya), new { id = nuevaPlaya.Id }, nuevaPlaya);
        }

        // PUT: api/Playas/{id}
        [HttpPut("{id}")]
        public IActionResult UpdatePlaya(int id, [FromBody] Playa playaActualizada)
        {
            if (id != playaActualizada.Id)
            {
                return BadRequest();
            }

            var playa = _context.Playa.Find(id);
            if (playa == null)
            {
                return NotFound();
            }

            // Actualiza las propiedades
            playa.Nombre = playaActualizada.Nombre;
            playa.Direccion = playaActualizada.Direccion;
            playa.Capacidad = playaActualizada.Capacidad;
            playa.Zona = playaActualizada.Zona;
            playa.Imagenes = playaActualizada.Imagenes;
            playa.Caracteristicas = playaActualizada.Caracteristicas;
            playa.Servicios = playaActualizada.Servicios;
            playa.Accesos = playaActualizada.Accesos;
            playa.PromedioValoracion = playaActualizada.PromedioValoracion;

            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Playas/{id}
        [HttpDelete("{id}")]
        public IActionResult DeletePlaya(int id)
        {
            var playa = _context.Playa.Find(id);
            if (playa == null)
            {
                return NotFound();
            }

            _context.Playa.Remove(playa); // Elimina la playa
            _context.SaveChanges();
            return NoContent();
        }
    }
}
