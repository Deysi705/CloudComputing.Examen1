using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudComputingExamen1.Models
{
    public class Pago
    {
        public int Id { get; set; } //PK
        public int Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string CodigoTransaccion { get; set; }
        public string Estado { get; set; }

        //FK
        public int MediosPagosId { get; set; }
        public int InscripcionesId { get; set; }

        // Relaciones
        public MedioPago? MediosPagos { get; set; }
        public Inscripcion? Inscripciones { get; set; }


    }
}
