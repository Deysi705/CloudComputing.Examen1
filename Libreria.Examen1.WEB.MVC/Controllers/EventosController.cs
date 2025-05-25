using CloudComputing.Examen1.API.Consumer;
using CloudComputing.Examen1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Libreria.Examen1.WEB.MVC.Controllers
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
            var data = Crud<Evento>.Get(id).Result;
            return View(data);
        }

        // GET: EventosController/Create
        public ActionResult Create()
        {
            ViewBag.ListaTipoEventos = ListaTipoEventos();
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
