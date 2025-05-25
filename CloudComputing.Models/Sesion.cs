using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudComputingExamen1.Models
{
    public class Sesion
    {
        public int Id { get; set; }//PK
        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Descripcion {  get; set; }

        //FK
        public int EspaciosId { get; set; }
        public int EventosId { get; set; }

        // Relaciones
        public Evento? Eventos { get; set; }
        public Espacio? Espacios { get; set; }
    }
}
