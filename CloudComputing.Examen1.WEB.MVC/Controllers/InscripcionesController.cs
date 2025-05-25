using CloudComputing.Examen1.API.Consumer;
using CloudComputingExamen1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Blazor;

namespace CloudComputing.Examen1.WEB.MVC.Controllers
{
    public class InscripcionesController : Controller
    {
        // GET: InscripcionesController
        public ActionResult Index()
        {
            var data=Crud<Inscripcion>.GetAll().Result;
            return View(data);
        }

        // GET: InscripcionesController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<Inscripcion>.Get(id).Result;
            return View(data);
        }

        // GET: InscripcionesController/Create
        public ActionResult Create()
        {
            ViewBag.ListaParticipantes = ListaParticipantes();
            ViewBag.ListaPagos = ListaPagos();
            return View();
        }
        private List<SelectListItem> ListaParticipantes()
        {
            var participantes = Crud<Participante>.GetAll().Result;
            var lista = participantes.Select(part => new SelectListItem
            {
                Value = part.Id.ToString(),
                Text = $"{part.Apellido} {part.Nombre}"
            }).ToList();
            return lista;
        }
        private List<SelectListItem> ListaPagos()
        {
            var pagos = Crud<Pago>.GetAll().Result;
            var lista = pagos.Select(pag => new SelectListItem
            {
                Value = pag.Id.ToString(),
                Text = pag.Estado
            }).ToList();
            return lista;
        }

        // POST: InscripcionesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Inscripcion inscripcion)
        {
            try
            {
                Crud<Inscripcion>.Create(inscripcion).Wait();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(inscripcion);
            }
        }

        // GET: InscripcionesController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.ListaParticipantes = ListaParticipantes();
            ViewBag.ListaPagos = ListaPagos();
            var data = Crud<Inscripcion>.Get(id).Result;
            return View(data);
        }

        // POST: InscripcionesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Inscripcion inscripcion)
        {
            try
            {
                Crud<Inscripcion>.Update(id, inscripcion).Wait();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(inscripcion);
            }
        }

        // GET: InscripcionesController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<Inscripcion>.Get(id).Result;
            return View(data);
        }

        // POST: InscripcionesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Inscripcion inscripcion)
        {
            try
            {
                Crud<Inscripcion>.Delete(id).Wait();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(inscripcion);
            }
        }
    }
}
