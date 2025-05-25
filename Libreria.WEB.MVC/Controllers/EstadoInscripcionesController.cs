using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.WEB.MVC.Controllers
{
    public class EstadoInscripcionesController : Controller
    {
        // GET: EstadoInscripcionesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: EstadoInscripcionesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EstadoInscripcionesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstadoInscripcionesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EstadoInscripcionesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EstadoInscripcionesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EstadoInscripcionesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EstadoInscripcionesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
