using Classmate.Models;
using Classmate.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Classmate.Controllers
{
    public class UsuarioController : Controller
    {

        private Service service;

        public UsuarioController() { service = new Service(); }




        #region Usuario



        // GET: UsuarioController/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: UsuarioController/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string nombreUsuario, string clave)
        {
            try
            {
                var obj = service.login(nombreUsuario, clave);
                return RedirectToAction("Index");
            }
            catch
            {
            }
            return View();
        }






        // GET: UsuarioController
        public ActionResult Index()
        {
            var model = service.mostrarUsuario();
            return View(model);
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }



        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    service.agregarUsuario(usuario);
                    return RedirectToAction("Login");

                }
            }
            catch
            {

            }
            return Login();
        }
    

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var usuario = service.buscarUsuario(id);
                return View(usuario);
            }
            catch (Exception)
            {
                return View();
            }
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service.actualizarUsuario(usuario);

                    return RedirectToAction(nameof(Index));
                }

            }
            catch
            {
                return View();
            }
            return View(usuario);
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var obj = service.buscarUsuario(id);
                service.eliminarUsuario(obj);
                return RedirectToAction("Login");
            }
            catch (Exception)
            {

            }
            return View();
        }
#endregion


















    }
}
