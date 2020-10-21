using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//referencia de proyectos DAL y EL
using EmergenciasChats.EL;
using EmergenciasChats.DAL;

namespace EmergenciasChats.BL
{
   public  class UsuarioHBL
    {
     
        //instancia de la clase DAL 
        private UsuarioHDAL usuarioHDAL = new UsuarioHDAL();

        public int Guardar (UsuarioH usuarioH)
        {
            return usuarioHDAL.Guarda(usuarioH);
        }



        //Metodo EDITAR
        public int Editar(UsuarioH usuarioH)
        {
            return usuarioHDAL.Modificar(usuarioH);
        }



        public UsuarioH FindUsuarioH(string id)
        {
            return usuarioHDAL.FindUsuarioH(id);
        }





















        //public int Delete(string id)
        //{
        //    return adminDAL.Delete(id);
        //}

        public List<UsuarioH> ListaUsuario()
        {
            return usuarioHDAL.ListAUsuario();
        }
    }
}
