using CloudComputing.Examen1.API.Consumer;
using CloudComputing.Examen1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Libreria.Examen1.WEB.MVC.Controllers
{
    public class TipoEventosController : Controller
    {
        // GET: TipoEventosController
        public ActionResult Index()
        {
            var data = Crud<TipoEvento>.GetAll().Result;
            return View(data);
        }

        // GET: TipoEventosController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<TipoEvento>.Get(id).Result;
            return View(data);
        }

        // GET: TipoEventosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoEventosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoEvento tipoEvento)
        {
            try
            {
                Crud<TipoEvento>.Create(tipoEvento).Wait();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(tipoEvento);
            }
        }

        // GET: TipoEventosController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Crud<TipoEvento>.Get(id).Result;
            return View(data);
        }

        // POST: TipoEventosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TipoEvento tipoEvento)
        {
            try
            {
                Crud<TipoEvento>.Update(id, tipoEvento).Wait();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(tipoEvento);
            }
        }

        // GET: TipoEventosController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<TipoEvento>.Get(id).Result;
            return View(data);
        }

        // POST: TipoEventosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Crud<TipoEvento>.Delete(id).Wait();
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
