using CloudComputing.Examen1.API.Consumer;
using CloudComputing.Examen1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Libreria.Examen1.WEB.MVC.Controllers
{
    public class PagosController : Controller
    {
        // GET: PagosController
        public ActionResult Index()
        {
            var data = Crud<Pago>.GetAll().Result;
            return View(data);
        }

        // GET: PagosController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<Pago>.Get(id).Result;
            return View(data);
        }

        // GET: PagosController/Create
        public ActionResult Create()
        {
            ViewBag.ListaMedioPagos = ListaMedioPagos();
            return View();
        }
        private List<SelectListItem> ListaMedioPagos()
        {
            var medioPagos = Crud<MedioPago>.GetAll().Result;
            var lista = medioPagos.Select(medpag => new SelectListItem
            {
                Value = medpag.Id.ToString(),
                Text = medpag.Nombre
            }).ToList();
            return lista;
        }

        // POST: PagosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pago pago)
        {
            try
            {
                Crud<Pago>.Create(pago).Wait();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(pago);
            }
        }

        // GET: PagosController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.ListaMedioPagos = ListaMedioPagos();
            var data = Crud<Pago>.Get(id).Result;
            return View(data);
        }

        // POST: PagosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Pago pago)
        {
            try
            {
                Crud<Pago>.Update(id, pago).Wait();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(pago);
            }
        }

        // GET: PagosController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<Pago>.Get(id).Result;
            return View(data);
        }

        // POST: PagosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Pago pago)
        {
            try
            {
                Crud<Pago>.Delete(id).Wait();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(pago);
            }
        }
    }
}
