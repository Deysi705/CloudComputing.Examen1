using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.WEB.MVC.Controllers
{
    public class MedioPagosController : Controller
    {
        // GET: MedioPagosController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MedioPagosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MedioPagosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedioPagosController/Create
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

        // GET: MedioPagosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MedioPagosController/Edit/5
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

        // GET: MedioPagosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MedioPagosController/Delete/5
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
