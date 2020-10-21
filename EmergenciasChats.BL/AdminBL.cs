using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//refe
using EmergenciasChats.EL;
using EmergenciasChats.DAL;

namespace EmergenciasChats.BL
{
  public class AdminBL
    {
        //
        private AdminDAL adminDAL = new AdminDAL();

        //Instancia de metodo de guardar
        public int Guardar(AdminEL admin)
        {
            //el insertAdmin es el metodo de la Dal
            return adminDAL.InsertAdmin(admin);
        }

        public int Editar(AdminEL administrador)
        {
            return adminDAL.Editar(administrador);
        }
        public AdminEL FindAdmin(string id)
        {
            return adminDAL.FindAdmin(id);
        }

        public int Delete(string id)
        {
            return adminDAL.Delete(id);
        }

        public List<AdminEL> ListAdministra()
        {
            return adminDAL.ListAdministra();
        }



       // login
        //public void logi(string Email, string Password)
        //{
        //    return adminDAL.login(Email, Password);
        //}
    }
}
