using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Classmate.Controllers
{
    public class PomodoroController : Controller
    {
        // GET: PomodoroController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PomodoroController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PomodoroController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PomodoroController/Create
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

        // GET: PomodoroController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PomodoroController/Edit/5
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

        // GET: PomodoroController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PomodoroController/Delete/5
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
