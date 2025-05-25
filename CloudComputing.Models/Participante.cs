namespace CloudComputingExamen1.Models
{
    public class Participante
    {
        public int Id {  get; set; }
        public string Cedula {  get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public string Institucion { get; set; }

        // Relaciones
        public List<Inscripcion>? Inscripciones { get; set; }

    }
}
