using CloudComputing.Examen1.API.Consumer;
using CloudComputing.Examen1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.Examen1.WEB.MVC.Controllers
{
    public class EstadoPagosController : Controller
    {
        // GET: EstadoPagosController
        public ActionResult Index()
        {
            var data = Crud<EstadoPago>.GetAll().Result;
            return View(data);
        }

        // GET: EstadoPagosController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<EstadoPago>.Get(id).Result;
            return View(data);
        }

        // GET: EstadoPagosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstadoPagosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EstadoPago estadoPago)
        {
            try
            {
                Crud<EstadoPago>.Create(estadoPago).Wait();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(estadoPago);
            }
        }

        // GET: EstadoPagosController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Crud<EstadoPago>.Get(id).Result;
            return View(data);
        }

        // POST: EstadoPagosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EstadoPago estadoPago)
        {
            try
            {
                Crud<EstadoPago>.Update(id, estadoPago).Wait();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(estadoPago);
            }
        }

        // GET: EstadoPagosController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<EstadoPago>.Get(id).Result;
            return View(data);
        }

        // POST: EstadoPagosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Crud<EstadoPago>.Delete(id).Wait();
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
