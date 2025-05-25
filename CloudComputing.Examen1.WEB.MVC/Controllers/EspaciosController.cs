using CloudComputing.Examen1.API.Consumer;
using CloudComputingExamen1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Blazor;

namespace CloudComputing.Examen1.WEB.MVC.Controllers
{
    public class EspaciosController : Controller
    {
        // GET: EspaciosController
        public ActionResult Index()
        {
            var data=Crud<Espacio>.GetAll().Result;
            return View(data);
        }

        // GET: EspaciosController/Details/5
        public ActionResult Details(int id)
        {
            var data=Crud<Espacio>.Get(id).Result;
            return View(data);
        }

        // GET: EspaciosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EspaciosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Espacio espacio)
        {
            try
            {
                Crud<Espacio>.Create(espacio).Wait();
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(espacio);
            }
        }

        // GET: EspaciosController/Edit/5
        public ActionResult Edit(int id)
        {
            var data=Crud<Espacio>.Get(id).Result;
            return View(data);
        }

        // POST: EspaciosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Espacio espacio)
        {
            try
            {
                Crud<Espacio>.Update(id, espacio).Wait();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(espacio);
            }
        }

        // GET: EspaciosController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<Espacio>.Get(id).Result;
            return View(data);
        }

        // POST: EspaciosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Crud<Espacio>.Delete(id).Wait();
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
