using CloudComputing.Examen1.API.Consumer;
using CloudComputing.Examen1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.Examen1.WEB.MVC.Controllers
{
    public class EstadoCertificadosController : Controller
    {
        // GET: EstadoCertificadosController
        public ActionResult Index()
        {
            var data = Crud<EstadoCertificado>.GetAll().Result;
            return View(data);
        }

        // GET: EstadoCertificadosController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<EstadoCertificado>.Get(id).Result;
            return View(data);
        }

        // GET: EstadoCertificadosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstadoCertificadosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EstadoCertificado estadoCertificado)
        {
            try
            {
                Crud<EstadoCertificado>.Create(estadoCertificado).Wait();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(estadoCertificado);
            }
        }

        // GET: EstadoCertificadosController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Crud<EstadoCertificado>.Get(id).Result;
            return View(data);
        }

        // POST: EstadoCertificadosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EstadoCertificado estadoCertificado)
        {
            try
            {
                Crud<EstadoCertificado>.Update(id, estadoCertificado).Wait();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(estadoCertificado);
            }
        }

        // GET: EstadoCertificadosController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<EstadoCertificado>.Get(id).Result;
            return View(data);
        }

        // POST: EstadoCertificadosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Crud<EstadoCertificado>.Delete(id).Wait();
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
