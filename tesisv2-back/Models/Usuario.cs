using System;

namespace tesisv2_back.Models
{
    public class Usuario
    {
        public int Id { get; set; } // Cambié UsuarioId a Id para consistencia
        public string UID { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public DateTime FechaRegistro { get; set; }
    }
}
