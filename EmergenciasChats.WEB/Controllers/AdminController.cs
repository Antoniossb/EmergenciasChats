using CitizenParticipation.BL;
using CitizenParticipation.EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CitizenParticipation.WEB.Controllers
{
    public class AdminController : Controller
    {

        //Intancias para acceder a los metodos de las clases BL Usuarios
        private AdminBL adminBL = new AdminBL();
        // GET: Admin 
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            return View(adminBL.ListAdmi());
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(string id)
        {

            return View(adminBL.FindAdmi((id)));
        }

        public ActionResult Delete(string id)
        {

            return View(adminBL.FindAdmi((id)));
        }

        public ActionResult Details(string id)
        {

            return View(adminBL.FindAdmi((id)));
        }

        [HttpPost]
        public int Create(Admin admin)
        {
            int r = 0;
            try
            {
                if(admin != null)
                {
                    return adminBL.Guardar(admin);
                }
                return r;     
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return -1;
            }
        }
        [HttpPost]
        public int Edit(Admin admin)
        {
            if (admin != null)
            {

                return adminBL.Editar(admin);
            }
            else
            {
                return -1;
            }
        }

        [HttpPost]
        public int Delete(string id, FormCollection collection)
        {
            if (id != null)
            {

                return adminBL.Delete(id);
            }
            else
            {
                return -1;
            }
        }

    }
}