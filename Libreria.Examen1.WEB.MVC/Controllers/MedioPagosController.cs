using CloudComputing.Examen1.API.Consumer;
using CloudComputing.Examen1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.Examen1.WEB.MVC.Controllers
{
    public class MedioPagosController : Controller
    {
        // GET: MedioPagosController
        public ActionResult Index()
        {
            var data = Crud<MedioPago>.GetAll().Result;
            return View(data);
        }

        // GET: MedioPagosController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<MedioPago>.Get(id).Result;
            return View(data);
        }

        // GET: MedioPagosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedioPagosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MedioPago medioPago)
        {
            try
            {
                Crud<MedioPago>.Create(medioPago).Wait();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(medioPago);
            }
        }

        // GET: MedioPagosController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Crud<MedioPago>.Get(id).Result;
            return View(data);
        }

        // POST: MedioPagosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MedioPago medioPago)
        {
            try
            {
                Crud<MedioPago>.Update(id, medioPago).Wait();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(medioPago);
            }
        }

        // GET: MedioPagosController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<MedioPago>.Get(id).Result;
            return View(data);
        }

        // POST: MedioPagosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Crud<MedioPago>.Delete(id).Wait();
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
