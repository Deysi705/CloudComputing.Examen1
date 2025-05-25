using CloudComputing.Examen1.API.Consumer;
using CloudComputing.Examen1.Models;

namespace Libreria.Examen1.WEB.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var BaseUrl = "https://localhost:7299/api/";

            Crud<Certificado>.EndPoint = $"{BaseUrl}/Certificados";
            Crud<Espacio>.EndPoint = $"{BaseUrl}/Espacios";
            Crud<Especialidad>.EndPoint = $"{BaseUrl}/Especialidades";
            Crud<EstadoCertificado>.EndPoint = $"{BaseUrl}/EstadoCertificados";
            Crud<EstadoInscripcion>.EndPoint = $"{BaseUrl}/EstadoInscripciones";
            Crud<EstadoPago>.EndPoint = $"{BaseUrl}/EstadoPagos";
            Crud<Evento>.EndPoint = $"{BaseUrl}/Eventos";
            Crud<HistorialCertificado>.EndPoint = $"{BaseUrl}/HistorialCertificados";
            Crud<Inscripcion>.EndPoint = $"{BaseUrl}/Inscripciones";
            Crud<Institucion>.EndPoint = $"{BaseUrl}/Instituciones";
            Crud<MedioPago>.EndPoint = $"{BaseUrl}/MedioPagos";
            Crud<Pago>.EndPoint = $"{BaseUrl}/Pagos";
            Crud<Participante>.EndPoint = $"{BaseUrl}/Participantes";
            Crud<Ponente>.EndPoint = $"{BaseUrl}/Ponentes";
            Crud<Sesion>.EndPoint = $"{BaseUrl}/Sesiones";
            Crud<TipoEvento>.EndPoint = $"{BaseUrl}/TipoEventos";
            Crud<TipoInscripcion>.EndPoint = $"{BaseUrl}/TipoInscripciones";

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            app.UseCors("AllowAll");

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
