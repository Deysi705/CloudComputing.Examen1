using CloudComputing.Examen1.API.Consumer;
using CloudComputing.Examen1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.Examen1.WEB.MVC.Controllers
{
    public class ParticipantesController : Controller
    {
        // GET: ParticipantesController
        public ActionResult Index()
        {
            var data = Crud<Participante>.GetAll().Result;
            return View(data);
        }

        // GET: ParticipantesController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<Participante>.Get(id).Result;
            return View(data);
        }

        // GET: ParticipantesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ParticipantesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Participante participante)
        {
            try
            {
                Crud<Participante>.Create(participante).Wait();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(participante);
            }
        }

        // GET: ParticipantesController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Crud<Participante>.Get(id).Result;
            return View(data);
        }

        // POST: ParticipantesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Participante participante)
        {
            {
                try
                {
                    Crud<Participante>.Update(id, participante).Wait();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;
                    return View(participante);
                }
            }
        }

        // GET: ParticipantesController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<Participante>.Get(id).Result;
            return View(data);
        }

        // POST: ParticipantesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Crud<Participante>.Delete(id).Wait();
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
