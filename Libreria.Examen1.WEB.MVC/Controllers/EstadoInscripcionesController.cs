using CloudComputing.Examen1.API.Consumer;
using CloudComputing.Examen1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.Examen1.WEB.MVC.Controllers
{
    public class EstadoInscripcionesController : Controller
    {
        // GET: EstadoInscripcionesController
        public ActionResult Index()
        {
            var data = Crud<EstadoInscripcion>.GetAll().Result;
            return View(data);
        }

        // GET: EstadoInscripcionesController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<EstadoInscripcion>.Get(id).Result;
            return View(data);
        }

        // GET: EstadoInscripcionesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstadoInscripcionesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EstadoInscripcion estadoInscripcion)
        {
            try
            {
                Crud<EstadoInscripcion>.Create(estadoInscripcion).Wait();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(estadoInscripcion);
            }
        }

        // GET: EstadoInscripcionesController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Crud<EstadoInscripcion>.Get(id).Result;
            return View(data);
        }

        // POST: EstadoInscripcionesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EstadoInscripcion estadoInscripcion)
        {
            try
            {
                Crud<EstadoInscripcion>.Update(id, estadoInscripcion).Wait();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(estadoInscripcion);
            }
        }

        // GET: EstadoInscripcionesController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<EstadoInscripcion>.Get(id).Result;
            return View(data);
        }

        // POST: EstadoInscripcionesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Crud<EstadoInscripcion>.Delete(id).Wait();
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
