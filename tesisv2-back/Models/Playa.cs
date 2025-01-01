using Microsoft.EntityFrameworkCore;

namespace tesisv2_back.Models
{
    public class Playa // Cambié de Playas a Playa
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public int Capacidad { get; set; }
        public string Zona { get; set; } = string.Empty;
        public string Imagenes { get; set; } = string.Empty;
        public string Caracteristicas { get; set; } = string.Empty;
        public string Servicios { get; set; } = string.Empty;
        public string Accesos { get; set; } = string.Empty;

        [Precision(5, 1)] // Define precisión y escala
        public decimal PromedioValoracion { get; set; }
    }
}
