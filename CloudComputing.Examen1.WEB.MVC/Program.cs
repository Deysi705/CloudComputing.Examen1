using CloudComputing.Examen1.API.Consumer;
using CloudComputingExamen1.Models;

namespace CloudComputing.Examen1.WEB.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {

            /* var BaseUrl = "https://localhost:7296/api";*/

            var BaseUrl = "apputn202502-h4cdgff0hhhyg3dn.westus-01.azurewebsites.net/api";

            Crud<Certificado>.EndPoint = $"{BaseUrl}/Certificados";
            Crud<Espacio>.EndPoint = $"{BaseUrl}/Espacios";
            Crud<Evento>.EndPoint = $"{BaseUrl}/Eventos";
            Crud<EventoPonente>.EndPoint = $"{BaseUrl}/EventoPonentes";
            Crud<HistoricoCertificado>.EndPoint = $"{BaseUrl}/HistoricoCertificados";
            Crud<Inscripcion>.EndPoint = $"{BaseUrl}/Inscripciones";
            Crud<MedioPago>.EndPoint = $"{BaseUrl}/MedioPagos";
            Crud<Pago>.EndPoint = $"{BaseUrl}/Pagos";
            Crud<Participante>.EndPoint = $"{BaseUrl}/Participantes";
            Crud<Ponente>.EndPoint = $"{BaseUrl}/Ponentes";
            Crud<Sesion>.EndPoint = $"{BaseUrl}/Sesiones";
            Crud<TipoEvento>.EndPoint = $"{BaseUrl}/TipoEventos";

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
