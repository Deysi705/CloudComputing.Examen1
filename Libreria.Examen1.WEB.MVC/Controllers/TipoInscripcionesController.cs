using CloudComputing.Examen1.API.Consumer;
using CloudComputing.Examen1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.Examen1.WEB.MVC.Controllers
{
    public class TipoInscripcionesController : Controller
    {
        // GET: TipoInscripcionesController
        public ActionResult Index()
        {
            var data = Crud<TipoInscripcion>.GetAll().Result;
            return View(data);
        }

        // GET: TipoInscripcionesController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<TipoInscripcion>.Get(id).Result;
            return View(data);
        }

        // GET: TipoInscripcionesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoInscripcionesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoInscripcion tipoInscripcion)
        {
            try
            {
                Crud<TipoInscripcion>.Create(tipoInscripcion).Wait();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(tipoInscripcion);
            }
        }

        // GET: TipoInscripcionesController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Crud<TipoInscripcion>.Get(id).Result;
            return View(data);
        }

        // POST: TipoInscripcionesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TipoInscripcion tipoInscripcion)
        {
            try
            {
                Crud<TipoInscripcion>.Update(id, tipoInscripcion).Wait();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(tipoInscripcion);
            }
        }

        // GET: TipoInscripcionesController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<TipoInscripcion>.Get(id).Result;
            return View(data);
        }

        // POST: TipoInscripcionesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Crud<TipoInscripcion>.Delete(id).Wait();
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
