using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudComputing.Examen1.Models
{
    public class TipoEvento
    {
        public int Id { get; set; } //PK
        public string Nombre { get; set; }

        // Relaciones
        public List<Evento>? Eventos { get; set; }
    }
}
