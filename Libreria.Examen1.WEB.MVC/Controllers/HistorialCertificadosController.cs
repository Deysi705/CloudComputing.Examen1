using CloudComputing.Examen1.API.Consumer;
using CloudComputing.Examen1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Libreria.Examen1.WEB.MVC.Controllers
{
    public class HistorialCertificadosController : Controller
    {
        // GET: HistorialCertificadosController
        public ActionResult Index()
        {
            var data = Crud<HistorialCertificado>.GetAll().Result;
            return View(data);
        }

        // GET: HistorialCertificadosController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<HistorialCertificado>.Get(id).Result;
            return View(data);
        }       

        // GET: HistorialCertificadosController/Create
        public ActionResult Create()
        {
            ViewBag.ListaEventos = ListaEventos();
            ViewBag.ListaParticipantes = ListaParticipantes();
            ViewBag.ListaCertificados = ListaCertificados();
            ViewBag.ListaPagos = ListaPagos();
            return View();
        }
        private List<SelectListItem> ListaEventos()
        {
            var eventos = Crud<Evento>.GetAll().Result;
            var lista = eventos.Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.Nombre
            }).ToList();
            return lista;
        }

        private List<SelectListItem> ListaParticipantes()
        {
            var participantes = Crud<Participante>.GetAll().Result;
            var lista = participantes.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Nombre
            }).ToList();
            return lista;
        }
        private List<SelectListItem> ListaCertificados()
        {
            var certificados = Crud<Certificado>.GetAll().Result;
            var lista = certificados.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Nombre
            }).ToList();
            return lista;
        }
        private List<SelectListItem> ListaPagos()
        {
            var pagos = Crud<Pago>.GetAll().Result;
            var lista = pagos.Select(pag => new SelectListItem
            {
                Value = pag.Id.ToString()
            }).ToList();
            return lista;
        }

        // POST: HistorialCertificadosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HistorialCertificado historialCertificado)
        {
            try
            {
                Crud<HistorialCertificado>.Create(historialCertificado).Wait();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(historialCertificado);
            }
        }

        // GET: HistorialCertificadosController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.ListaEventos = ListaEventos();
            ViewBag.ListaParticipantes = ListaParticipantes();
            ViewBag.ListaCertificados = ListaCertificados();
            ViewBag.ListaPagos = ListaPagos();
            var data = Crud<HistorialCertificado>.Get(id).Result;
            return View(data);
        }

        // POST: HistorialCertificadosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, HistorialCertificado historialCertificado)
        {
            try
            {
                Crud<HistorialCertificado>.Update(id, historialCertificado).Wait();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(historialCertificado);
            }
        }

        // GET: HistorialCertificadosController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<HistorialCertificado>.Get(id).Result;
            return View(data);
        }

        // POST: HistorialCertificadosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Crud<HistorialCertificado>.Delete(id).Wait();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
    }
}
