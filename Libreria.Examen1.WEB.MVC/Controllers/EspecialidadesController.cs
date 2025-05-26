using CloudComputing.Examen1.API.Consumer;
using CloudComputing.Examen1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.Examen1.WEB.MVC.Controllers
{
    public class EspecialidadesController : Controller
    {
        // GET: EspecialidadesController
        public ActionResult Index()
        {
            var data = Crud<Especialidad>.GetAll().Result;
            return View(data);
        }

        // GET: EspecialidadesController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<Especialidad>.Get(id).Result;
            return View(data);
        }

        // GET: EspecialidadesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EspecialidadesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Especialidad especialidad)
        {
            try
            {
                Crud<Especialidad>.Create(especialidad).Wait();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(especialidad);
            }
        }

        // GET: EspecialidadesController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Crud<Especialidad>.Get(id).Result;
            return View(data);
        }

        // POST: EspecialidadesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Especialidad especialidad)
        {
            try
            {
                Crud<Especialidad>.Update(id, especialidad).Wait();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(especialidad);
            }
        }

        // GET: EspecialidadesController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<Especialidad>.Get(id).Result;
            return View(data);
        }

        // POST: EspecialidadesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Crud<Especialidad>.Delete(id).Wait();
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
