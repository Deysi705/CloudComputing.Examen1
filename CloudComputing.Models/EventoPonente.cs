using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudComputingExamen1.Models
{
    public class EventoPonente
    {
        public int Id { get; set; }//PK
        
        //FK
        public int PonentesId { get; set; }
        public int EventosId { get; set; }

        //Relaciones
        public Ponente? Ponentes { get; set; }
        public Evento? Eventos { get; set; }

    }
}
