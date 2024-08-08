using Classmate.Models;
using Classmate.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Classmate.Controllers
{
    public class TemaClassController : Controller
    {

        private Service service;
        public TemaClassController() { service = new Service(); }




        // GET: TemaClassController
        public ActionResult Index()
        {
            var model = service.mostrarTemaClass();
            return View(model);
        }

        // GET: TemaClassController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TemaClassController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TemaClassController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TemaClass temaClass)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service.agregarTemaClass(temaClass);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
            }
            return View();
        }

        // GET: TemaClassController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var tema = service.buscarTemaClass(id);
                return View(tema);
            }
            catch (Exception)
            {
                return View();
            }
        }

        // POST: TemaClassController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TemaClass temaClass)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service.actualizarTemaClass(temaClass);

                    return RedirectToAction(nameof(Index));
                }

            }
            catch
            {
                return View();
            }
            return View(temaClass);
        }

        // GET: TemaClassController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var obj = service.buscarTemaClass(id);
                service.eliminarTemaClass(obj);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
            }
            return View();
        }

        // POST: TemaClassController/Delete/5
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
