using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudComputingExamen1.Models
{
    public class Certificado
    {
        public int Id { get; set; } //PK
        public DateTime FechaEmision { get; set; }
        public string Nombre {  get; set; }
        public string Cuerpo { get; set; }
        public string UrlPdf { get; set; }
        public string Estado { get; set; }

        //FK
        public int EventosId { get; set; }

        // Relaciones
        public Evento? Eventos { get; set; }       
        
    }
}
