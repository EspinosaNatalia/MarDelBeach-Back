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

        // POST: api/Actividades/filtrar
        [HttpPost("filtrar")]
        public async Task<IActionResult> FiltrarActividades([FromBody] Filtro filtros)
        {
            var query = _context.Actividad.AsQueryable();

            // Aplicar filtros
            if (filtros.Teatros)
            {
                query = query.Where(a => a.Caracteristicas.Contains("Teatro")); // Filtro por teatros
            }

            if (filtros.Plazas)
            {
                query = query.Where(a => a.Caracteristicas.Contains("Plaza")); // Filtro por plazas
            }

            if (filtros.Restaurantes)
            {
                query = query.Where(a => a.Caracteristicas.Contains("Restaurante")); // Filtro por restaurantes
            }



            var actividadesFiltradas = await query.ToListAsync(); // Ejecuta la consulta con los filtros aplicados
            return Ok(actividadesFiltradas); // Devuelve las actividades filtradas
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



        [HttpPost("valorar")]
        public IActionResult AgregarValoracion([FromBody] Valoracion nuevaValoracion)
        {
            if (ModelState.IsValid)
            {
                // Si la valoración está relacionada con una Actividad
                if (nuevaValoracion.ActividadId.HasValue)
                {
                    var actividad = _context.Actividad.Find(nuevaValoracion.ActividadId);
                    if (actividad != null)
                    {
                        // Agregar la valoración
                        _context.Valoraciones.Add(nuevaValoracion);
                        _context.SaveChanges();

                        // Calcular el promedio de valoraciones para la Actividad
                        var promedio = (decimal)_context.Valoraciones
                            .Where(v => v.ActividadId == nuevaValoracion.ActividadId)
                            .Average(v => v.Estrellas);

                        actividad.PromedioValoracion = promedio;
                        _context.SaveChanges();
                    }
                }

                return Ok("Valoración agregada correctamente");
            }
            return BadRequest("Datos inválidos");
        }





        [HttpDelete("valoracion/{id}")]
        public IActionResult EliminarValoracion(int id, [FromQuery] string usuario)
        {
            var valoracion = _context.Valoraciones.FirstOrDefault(v => v.Id == id && v.Usuario == usuario);
            if (valoracion == null)
            {
                return NotFound("Valoración no encontrada o no es tuya");
            }

            _context.Valoraciones.Remove(valoracion);
            _context.SaveChanges();

            return Ok("Valoración eliminada correctamente");
        }



    }
}