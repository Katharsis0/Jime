using Classmate.Models;
using Classmate.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Classmate.Controllers
{
    public class HabitoClassController : Controller
    {

        private Service service;
        public HabitoClassController() { service = new Service(); }

        // GET: HabitoClassController
        public ActionResult Index()
        {
            var model = service.mostrarHabitoClass();
            return View(model);
        }

        // GET: HabitoClassController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HabitoClassController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HabitoClassController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HabitoClass habitoClass)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service.agregarHabitoClass(habitoClass);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
            }
            return View();
        }

        // GET: HabitoClassController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var habito = service.buscarHabitoClass(id);
                return View(habito);
            }
            catch (Exception)
            {
                return View();
            }
        }

        // POST: HabitoClassController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HabitoClass habitoClass)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service.actualizarHabitoClass(habitoClass);

                    return RedirectToAction(nameof(Index));
                }

            }
            catch
            {
                return View();
            }
            return View(habitoClass);
        }

        // GET: HabitoClassController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var obj = service.buscarHabitoClass(id);
                service.eliminarHabitoClass(obj);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
            }
            return View();
        }

        // POST: HabitoClassController/Delete/5
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
