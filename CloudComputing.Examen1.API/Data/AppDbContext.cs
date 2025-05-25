using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CloudComputingExamen1.Models;

namespace CloudComputing.Examen1.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<CloudComputingExamen1.Models.Certificado> Certificados { get; set; } = default!;
        public DbSet<CloudComputingExamen1.Models.Espacio> Espacios { get; set; } = default!;
        public DbSet<CloudComputingExamen1.Models.Evento> Eventos { get; set; } = default!;
        public DbSet<CloudComputingExamen1.Models.EventoPonente> EventosPonentes { get; set; } = default!;
        public DbSet<CloudComputingExamen1.Models.HistoricoCertificado> HistoricoCertificados { get; set; } = default!;
        public DbSet<CloudComputingExamen1.Models.Inscripcion> Inscripciones { get; set; } = default!;
        public DbSet<CloudComputingExamen1.Models.MedioPago> MediosPagos { get; set; } = default!;
        public DbSet<CloudComputingExamen1.Models.Pago> Pagos { get; set; } = default!;
        public DbSet<CloudComputingExamen1.Models.Participante> Participantes { get; set; } = default!;
        public DbSet<CloudComputingExamen1.Models.Ponente> Ponentes { get; set; } = default!;
        public DbSet<CloudComputingExamen1.Models.Sesion> Sesiones { get; set; } = default!;
        public DbSet<CloudComputingExamen1.Models.TipoEvento> TipoEventos { get; set; } = default!;
    }
}
