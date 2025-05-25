using CloudComputing.Examen1.API.Consumer;
using CloudComputingExamen1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Blazor;

namespace CloudComputing.Examen1.WEB.MVC.Controllers
{
    public class HistoricoCertificadosController : Controller
    {
        // GET: HistoricoCertificadosController
        public ActionResult Index()
        {
            return View();
        }

        // GET: HistoricoCertificadosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HistoricoCertificadosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HistoricoCertificadosController/Create
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

        // GET: HistoricoCertificadosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HistoricoCertificadosController/Edit/5
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

        // GET: HistoricoCertificadosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HistoricoCertificadosController/Delete/5
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
