namespace tesisv2_back.Controllers
{
    public class ValoracionesController
    {
        [HttpGet("valoraciones")]
        public IActionResult ObtenerValoraciones(int? id)
        {
            // Si el id es null, retornamos un bad request.
            if (id == null)
            {
                return BadRequest("Se debe proporcionar un id.");
            }

            // Traer las valoraciones por PlayaId o ActividadId, dependiendo de cuál esté presente.
            var valoraciones = _context.Valoraciones
                .Where(v => v.PlayaId == id || v.ActividadId == id)
                .ToList();  // Traemos las valoraciones que coinciden con el id

            if (valoraciones == null || !valoraciones.Any())
            {
                return NotFound("No se encontraron valoraciones para este id.");
            }

            return Ok(valoraciones);  // Retornamos las valoraciones
        }

    }
}
