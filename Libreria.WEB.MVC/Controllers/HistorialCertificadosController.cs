using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.WEB.MVC.Controllers
{
    public class HistorialCertificadosController : Controller
    {
        // GET: HistorialCertificadosController
        public ActionResult Index()
        {
            return View();
        }

        // GET: HistorialCertificadosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HistorialCertificadosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HistorialCertificadosController/Create
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

        // GET: HistorialCertificadosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HistorialCertificadosController/Edit/5
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

        // GET: HistorialCertificadosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HistorialCertificadosController/Delete/5
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
