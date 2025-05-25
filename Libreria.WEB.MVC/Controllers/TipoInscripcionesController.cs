using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.WEB.MVC.Controllers
{
    public class TipoInscripcionesController : Controller
    {
        // GET: TipoInscripcionesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TipoInscripcionesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TipoInscripcionesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoInscripcionesController/Create
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

        // GET: TipoInscripcionesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TipoInscripcionesController/Edit/5
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

        // GET: TipoInscripcionesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TipoInscripcionesController/Delete/5
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
