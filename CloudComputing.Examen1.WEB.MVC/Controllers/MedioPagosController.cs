using CloudComputing.Examen1.API.Consumer;
using CloudComputingExamen1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Blazor;

namespace CloudComputing.Examen1.WEB.MVC.Controllers
{
    public class MedioPagosController : Controller
    {
        // GET: MediosPagosController
        public ActionResult Index()
        {
            var data = Crud<MedioPago>.GetAll().Result;
            return View(data);
        }

        // GET: MediosPagosController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<MedioPago>.Get(id).Result;
            return View(data);
        }

        // GET: MediosPagosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MediosPagosController/Create
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

        // GET: MediosPagosController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Crud<MedioPago>.Get(id).Result;
            return View(data);
        }

        // POST: MediosPagosController/Edit/5
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

        // GET: MediosPagosController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<MedioPago>.Get(id).Result;
            return View(data);
        }

        // POST: MediosPagosController/Delete/5
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
