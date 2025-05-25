namespace CloudComputing.Examen1.Models
{
    public class Participante
    {
        public int Id { get; set; }//PK
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }

        //FK
        public int InstitucionId { get; set; }

        // Relaciones
        public Institucion? Instituciones { get; set; }
        public List<Inscripcion>? Inscripciones { get; set; }
    }
}
