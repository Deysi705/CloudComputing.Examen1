using CloudComputing.Examen1.API.Consumer;
using CloudComputingExamen1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Blazor;

namespace CloudComputing.Examen1.WEB.MVC.Controllers
{
    public class EventosController : Controller
    {
        // GET: EventosController
        public ActionResult Index()
        {
            var data = Crud<Evento>.GetAll().Result;
            return View(data);
        }

        // GET: EventosController/Details/5
        public ActionResult Details(int id)
        {
            var data=Crud<Evento>.Get(id).Result;
            return View(data);
        }

        // GET: EventosController/Create
        public ActionResult Create()
        {
            ViewBag.ListaTipoEventos = ListaTipoEventos();
            ViewBag.ListaEventoOponentes = ListaEventoOponentes();
            ViewBag.ListaSesiones = ListaSesiones();
            ViewBag.ListaInscripciones = ListaInscripciones();
            return View();
        }        
        private List<SelectListItem> ListaTipoEventos()
        {
            var tipoeventos = Crud<TipoEvento>.GetAll().Result;
            var lista = tipoeventos.Select(tipev => new SelectListItem
            {
                Value = tipev.Id.ToString(),
                Text = tipev.Nombre
            }).ToList();
            return lista;
        }
       private List<SelectListItem> ListaEventoOponentes()
        {
            var eventoOponentes = Crud<EventoPonente>.GetAll().Result;
            var lista = eventoOponentes.Select(evenop => new SelectListItem
            {
                Value = evenop.Id.ToString()
            }).ToList();
            return lista;
        }
        private List<SelectListItem> ListaSesiones()
        {
            var sesiones = Crud<Sesion>.GetAll().Result;
            var lista = sesiones.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Nombre
            }).ToList();
            return lista;
        }
        private List<SelectListItem> ListaInscripciones()
        {
            var inscripciones = Crud<Inscripcion>.GetAll().Result;
            var lista = inscripciones.Select(insc => new SelectListItem
            {
                Value = insc.Id.ToString(),
                Text = insc.Estado
            }).ToList();
            return lista;
        }

        // POST: EventosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Evento evento)
        {
            try
            {
                Crud<Evento>.Create(evento).Wait();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex) 
            {
                ModelState.AddModelError("", ex.Message);
                return View(evento);
            }
        }

        // GET: EventosController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.ListaTipoEventos = ListaTipoEventos();
            ViewBag.ListaEventoOponentes = ListaEventoOponentes();
            ViewBag.ListaSesiones = ListaSesiones();
            ViewBag.ListaInscripciones = ListaInscripciones();
            var data = Crud<Evento>.Get(id).Result;
            return View(data);
        }

        // POST: EventosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Evento evento)
        {
            try
            {
                Crud<Evento>.Update(id, evento).Wait();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(evento);
            }
        }

        // GET: EventosController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<Evento>.Get(id).Result;
            return View(data);
        }

        // POST: EventosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Evento evento)
        {
            try
            {
                Crud<Evento>.Delete(id).Wait();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(evento);
            }
        }
    }
}
