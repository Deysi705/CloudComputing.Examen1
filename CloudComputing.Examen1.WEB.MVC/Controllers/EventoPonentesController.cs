using CloudComputing.Examen1.API.Consumer;
using CloudComputingExamen1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Blazor;

namespace CloudComputing.Examen1.WEB.MVC.Controllers
{
    public class EventoPonentesController : Controller
    {
        // GET: EventosPonentesController
        public ActionResult Index()
        {
            var data = Crud<EventoPonente>.GetAll().Result;
            return View(data);
        }

        // GET: EventosPonentesController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<EventoPonente>.Get(id).Result;
            return View(data);
        }

        // GET: EventosPonentesController/Create
        public ActionResult Create()
        {
            ViewBag.ListaEventos = ListaEventos();
            ViewBag.ListaPonentes = ListaPonentes();
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
        
        private List<SelectListItem> ListaPonentes()
        {
            var ponentes = Crud<Ponente>.GetAll().Result;
            var lista = ponentes.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Nombre
            }).ToList();
            return lista;
        }
        
        // POST: EventosPonentesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventoPonente eventoPonente)
        {
            try
            {
                Crud<EventoPonente>.Create(eventoPonente).Wait();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(eventoPonente);
            }
        }

        // GET: EventosPonentesController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.ListaEventos = ListaEventos();
            ViewBag.ListaPonentes = ListaPonentes();
            var data = Crud<EventoPonente>.Get(id).Result;
            return View(data);
        }

        // POST: EventosPonentesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EventoPonente eventoPonente)
        {
            try
            {
                Crud<EventoPonente>.Update(id, eventoPonente).Wait();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(eventoPonente);
            }
        }

        // GET: EventosPonentesController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<EventoPonente>.Get(id).Result;
            return View(data);
        }

        // POST: EventosPonentesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, EventoPonente eventoPonente)
        {
            try
            {
                Crud<EventoPonente>.Delete(id).Wait();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(eventoPonente);
            }
        }
    }
}
