using CloudComputing.Examen1.API.Consumer;
using CloudComputing.Examen1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Libreria.Examen1.WEB.MVC.Controllers
{
    public class CertificadosController : Controller
    {
        // GET: CertificadosController
        public ActionResult Index()
        {
            var data = Crud<Certificado>.GetAll().Result;
            return View(data);
        }

        // GET: CertificadosController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<Certificado>.Get(id).Result;
            return View(data);
        }

        // GET: CertificadosController/Create
        public ActionResult Create()
        {
            ViewBag.ListaEventos = ListaEventos();
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

        // POST: CertificadosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Certificado certificado)
        {
            try
            {
                Crud<Certificado>.Create(certificado).Wait();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(certificado);
            }
        }

        // GET: CertificadosController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.ListaEventos = ListaEventos();
            var data = Crud<Certificado>.Get(id).Result;
            return View(data);
        }

        // POST: CertificadosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Certificado certificado)
        {
            try
            {
                Crud<Certificado>.Update(id, certificado).Wait();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(certificado);
            }
        }

        // GET: CertificadosController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<Certificado>.Get(id).Result;
            return View(data);
        }

        // POST: CertificadosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Certificado certificado)
        {
            try
            {
                Crud<Certificado>.Delete(id).Wait();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(certificado);
            }
        }
    }
}
