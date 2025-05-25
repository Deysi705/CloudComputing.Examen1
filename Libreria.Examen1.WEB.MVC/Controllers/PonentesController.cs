using CloudComputing.Examen1.API.Consumer;
using CloudComputing.Examen1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.Examen1.WEB.MVC.Controllers
{
    public class PonentesController : Controller
    {
        // GET: PonentesController
        public ActionResult Index()
        {
            var data = Crud<Ponente>.GetAll().Result;
            return View(data);
        }

        // GET: PonentesController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<Ponente>.Get(id).Result;
            return View(data);
        }

        // GET: PonentesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PonentesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ponente ponente)
        {
            try
            {
                Crud<Ponente>.Create(ponente).Wait();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(ponente);
            }
        }

        // GET: PonentesController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Crud<Ponente>.Get(id).Result;
            return View(data);
        }

        // POST: PonentesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Ponente ponente)
        {
            try
            {
                Crud<Ponente>.Update(id, ponente).Wait();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(ponente);
            }
        }

        // GET: PonentesController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<Ponente>.Get(id).Result;
            return View(data);
        }

        // POST: PonentesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Crud<Ponente>.Delete(id).Wait();
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
