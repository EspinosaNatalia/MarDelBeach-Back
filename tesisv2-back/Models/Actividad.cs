using Microsoft.EntityFrameworkCore;

namespace tesisv2_back.Models
{
    public class Actividad // Mantengo el singular
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Imagen { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Zona { get; set; } = string.Empty;
        public string Caracteristicas { get; set; } = string.Empty;
        public string Servicios { get; set; } = string.Empty;
        public string Accesos { get; set; } = string.Empty;

        [Precision(5, 1)] // Define precisión y escala
        public decimal PromedioValoracion { get; set; }

        public ICollection<Valoracion> Valoraciones { get; set; }  // Relación de una actividad con muchas valoraciones
    }
}
