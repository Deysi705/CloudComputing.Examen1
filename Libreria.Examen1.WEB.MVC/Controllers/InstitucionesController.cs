using CloudComputing.Examen1.API.Consumer;
using CloudComputing.Examen1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.Examen1.WEB.MVC.Controllers
{
    public class InstitucionesController : Controller
    {
        // GET: InstitucionesController
        public ActionResult Index()
        {
            var data = Crud<Institucion>.GetAll().Result;
            return View(data);
        }

        // GET: InstitucionesController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<Institucion>.Get(id).Result;
            return View(data);
        }

        // GET: InstitucionesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InstitucionesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Institucion institucion)
        {
            try
            {
                Crud<Institucion>.Create(institucion).Wait();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(institucion);
            }
        }

        // GET: InstitucionesController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Crud<Institucion>.Get(id).Result;
            return View(data);
        }

        // POST: InstitucionesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Institucion institucion)
        {
            try
            {
                Crud<Institucion>.Update(id, institucion).Wait();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(institucion);
            }
        }

        // GET: InstitucionesController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<Institucion>.Get(id).Result;
            return View(data);
        }

        // POST: InstitucionesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Crud<Institucion>.Delete(id).Wait();
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
