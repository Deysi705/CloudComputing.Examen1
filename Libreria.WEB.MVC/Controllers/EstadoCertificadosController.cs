using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.WEB.MVC.Controllers
{
    public class EstadoCertificadosController : Controller
    {
        // GET: EstadoCertificadosController
        public ActionResult Index()
        {
            return View();
        }

        // GET: EstadoCertificadosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EstadoCertificadosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstadoCertificadosController/Create
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

        // GET: EstadoCertificadosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EstadoCertificadosController/Edit/5
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

        // GET: EstadoCertificadosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EstadoCertificadosController/Delete/5
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
