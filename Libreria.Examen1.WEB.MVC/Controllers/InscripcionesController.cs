using CloudComputing.Examen1.API.Consumer;
using CloudComputing.Examen1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Libreria.Examen1.WEB.MVC.Controllers
{
    public class InscripcionesController : Controller
    {
        // GET: InscripcionesController
        public ActionResult Index()
        {
            var data = Crud<Inscripcion>.GetAll().Result;
            return View(data);
        }

        // GET: InscripcionesController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<Inscripcion>.Get(id).Result;
            return View(data);
        }

        // GET: InscripcionesController/Create
        public ActionResult Create()
        {
            ViewBag.ListaParticipantes = ListaParticipantes();
            ViewBag.ListaEstadoInscripciones = ListaEstadoInscripciones();
            ViewBag.ListaEventos = ListaEventos();
            ViewBag.ListaTipoInscripciones = ListaTipoInscripciones();
            return View();
        }
        private List<SelectListItem> ListaParticipantes()
        {
            var participantes = Crud<Participante>.GetAll().Result;
            var lista = participantes.Select(part => new SelectListItem
            {
                Value = part.Id.ToString(),
                Text = $"{part.Apellido} {part.Nombre}"
            }).ToList();
            return lista;
        }
        private List<SelectListItem> ListaTipoInscripciones()
        {
            var tipoInscripciones = Crud<TipoInscripcion>.GetAll().Result;
            var lista = tipoInscripciones.Select(tipInsc => new SelectListItem
            {
                Value = tipInsc.Id.ToString(),
                Text = tipInsc.Nombre
            }).ToList();
            return lista;
        }
        private List<SelectListItem> ListaEstadoInscripciones()
        {
            var estadoInscripciones = Crud<EstadoInscripcion>.GetAll().Result;
            var lista = estadoInscripciones.Select(estInsc => new SelectListItem
            {
                Value = estInsc.Id.ToString(),
                Text = estInsc.Nombre
            }).ToList();
            return lista;
        }
        private List<SelectListItem> ListaEventos()
        {
            var eventos = Crud<TipoInscripcion>.GetAll().Result;
            var lista = eventos.Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.Nombre
            }).ToList();
            return lista;
        }

        // POST: InscripcionesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Inscripcion inscripcion)
        {
            try
            {
                Crud<Inscripcion>.Create(inscripcion).Wait();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(inscripcion);
            }
        }

        // GET: InscripcionesController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.ListaParticipantes = ListaParticipantes();
            ViewBag.ListaEstadoInscripciones = ListaEstadoInscripciones();
            ViewBag.ListaEventos = ListaEventos();
            ViewBag.ListaTipoInscripciones = ListaTipoInscripciones();
            var data = Crud<Inscripcion>.Get(id).Result;
            return View(data);
        }

        // POST: InscripcionesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Inscripcion inscripcion)
        {
            try
            {
                Crud<Inscripcion>.Update(id, inscripcion).Wait();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(inscripcion);
            }
        }

        // GET: InscripcionesController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<Inscripcion>.Get(id).Result;
            return View(data);
        }

        // POST: InscripcionesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Inscripcion inscripcion)
        {
            try
            {
                Crud<Inscripcion>.Delete(id).Wait();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(inscripcion);
            }
        }
    }
}
