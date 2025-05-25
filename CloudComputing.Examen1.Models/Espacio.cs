using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudComputing.Examen1.Models
{
    public class Espacio
    {
        public int Id { get; set; } //PK
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
        public int Capacidad { get; set; }

        // Relaciones
        public List<Sesion>? Sesiones { get; set; }
    }
}
