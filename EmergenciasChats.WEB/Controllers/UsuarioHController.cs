using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using  referenia de proyectos
using EmergenciasChats.BL;
using EmergenciasChats.EL;

namespace EmergenciasChats.WEB.Controllers
{
    

    public class UsuarioHController : Controller
    {
        //instancia de la clase BL
        private UsuarioHBL usuarioHBL = new UsuarioHBL();
        // GET: UsuarioH
        public ActionResult Index()
        {
            return View();
        }
        //crear nuevos datos
        public ActionResult Create()
        {
            return View();
        }







        //Lista de datos
        public ActionResult UsuarioHLista()
        {
            return View(usuarioHBL.ListaUsuario());
        }
        //[Authorize]
        public JsonResult ListUsuarioH()
        {
            return Json(usuarioHBL.ListaUsuario(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListAUsuario(string id)
        {
            return Json(usuarioHBL.FindUsuarioH(id), JsonRequestBehavior.AllowGet);
        }



        //metodo Editar
        public ActionResult Edit(string id)
        {

            return View(usuarioHBL.FindUsuarioH((id)));
        }






















        //metodo Guardar
        [HttpPost]
        public int Create(UsuarioH usuarioH)
        {
            int r = 0;
            try
            {
                if (usuarioH != null)
                {
                    return usuarioHBL.Guardar(usuarioH);
                }
                return r;
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return -1;
            }
        }







        //Metodo Editar
        [HttpPost]
        public int Edit(UsuarioH usuarioH)
        {
            if (usuarioH != null)
            {

                return usuarioHBL.Editar(usuarioH);
            }
            else
            {
                return -1;
            }
        }










    }

}