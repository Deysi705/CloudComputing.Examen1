using CloudComputing.Examen1.API.Consumer;
using CloudComputing.Examen1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Libreria.Examen1.WEB.MVC.Controllers
{
    public class SesionesController : Controller
    {
        // GET: SesionesController
        public ActionResult Index()
        {
            var data = Crud<Sesion>.GetAll().Result;
            return View(data);
        }

        // GET: SesionesController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<Sesion>.Get(id).Result;
            return View(data);
        }

        // GET: SesionesController/Create
        public ActionResult Create()
        {
            ViewBag.ListaEspacios = ListaEspacios();
            return View();
        }
        private List<SelectListItem> ListaEspacios()
        {
            var espacios = Crud<Espacio>.GetAll().Result;
            var lista = espacios.Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.Nombre
            }).ToList();
            return lista;
        }

        // POST: SesionesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Sesion sesion)
        {
            try
            {
                Crud<Sesion>.Create(sesion).Wait();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(sesion);
            }
        }

        // GET: SesionesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SesionesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Sesion sesion)
        {
            try
            {
                Crud<Sesion>.Update(id, sesion).Wait();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(sesion);
            }
        }

        // GET: SesionesController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<Sesion>.Get(id).Result;
            return View(data);
        }

        // POST: SesionesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Sesion sesion)
        {
            try
            {
                Crud<Sesion>.Delete(id).Wait();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(sesion);
            }
        }
        }
    }
}
