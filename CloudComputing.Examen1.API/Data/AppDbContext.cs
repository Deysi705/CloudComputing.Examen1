using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CloudComputing.Examen1.Models;

namespace CloudComputing.Examen1.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<CloudComputing.Examen1.Models.Certificado> Certificado { get; set; } = default!;
        public DbSet<CloudComputing.Examen1.Models.Espacio> Espacio { get; set; } = default!;
        public DbSet<CloudComputing.Examen1.Models.Especialidad> Especialidad { get; set; } = default!;
        public DbSet<CloudComputing.Examen1.Models.EstadoCertificado> EstadoCertificado { get; set; } = default!;
        public DbSet<CloudComputing.Examen1.Models.EstadoInscripcion> EstadoInscripcion { get; set; } = default!;
        public DbSet<CloudComputing.Examen1.Models.EstadoPago> EstadoPago { get; set; } = default!;
        public DbSet<CloudComputing.Examen1.Models.Evento> Evento { get; set; } = default!;
        public DbSet<CloudComputing.Examen1.Models.HistorialCertificado> HistorialCertificado { get; set; } = default!;
        public DbSet<CloudComputing.Examen1.Models.Inscripcion> Inscripcion { get; set; } = default!;
        public DbSet<CloudComputing.Examen1.Models.Institucion> Institucion { get; set; } = default!;
        public DbSet<CloudComputing.Examen1.Models.MedioPago> MedioPago { get; set; } = default!;
        public DbSet<CloudComputing.Examen1.Models.Pago> Pago { get; set; } = default!;
        public DbSet<CloudComputing.Examen1.Models.Participante> Participante { get; set; } = default!;
        public DbSet<CloudComputing.Examen1.Models.Ponente> Ponente { get; set; } = default!;
        public DbSet<CloudComputing.Examen1.Models.Sesion> Sesion { get; set; } = default!;
        public DbSet<CloudComputing.Examen1.Models.TipoEvento> TipoEvento { get; set; } = default!;
        public DbSet<CloudComputing.Examen1.Models.TipoInscripcion> TipoInscripcion { get; set; } = default!;
    }
}
