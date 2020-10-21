using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//referencias de proyecto
using EmergenciasChats.EL;
// configurar firebase     
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
  
namespace EmergenciasChats.DAL 
{
    public  class AdminDAL
    {
        // instancia de iFirebase 
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "CPT7izztGnLhDZ8RFM3lfSiJxLOxsAf6UnrERsOd", 
            BasePath = "https://aplicacion-web-de-emergencias.firebaseio.com/"


        };

        IFirebaseClient client;

        //validar campo ingresados a firebase  para login
       
        ////////private readonly string Email;
        ////////private readonly string Password;
        //Metodo de guardar
        public int InsertAdmin(AdminEL admin) 
        {

            int r = 1;
            if ((admin.Nombres != null) && (admin.Apellidos != null) && (admin.Sexo != null)  && (admin.Rol != null)  && (admin.Telefono > 0) 
                && (admin.Direccion != null)  && (admin.NameUser != null ) && (admin.Email != null)  && (admin.Password != null))
            {
                AddAdminToFirebase(admin);
                return r;
            }
            else
            { 
                return 0;
            }

        }

        //metodo get  lista
        public List<AdminEL> ListAdministra()
        {

            {
                client = new FireSharp.FirebaseClient(config);
                FirebaseResponse response = client.Get("Admin");
                dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);

                var list = new List<AdminEL>();
                foreach (var item in data)
                {
                    list.Add(JsonConvert.DeserializeObject<AdminEL>(((JProperty)item).Value.ToString()));
                }
                return (list);
            }
        }


        public void AddAdminToFirebase(AdminEL administrador)
        { 
              
            try 
            {
                client = new FireSharp.FirebaseClient(config);
                var data = administrador;
                PushResponse response = client.Push("Admin/", data);
               
               // data.IDAdmin = response.Result.name;
               // data.IDAdmin = response.Result.name;
                SetResponse setResponse = client.Set("Admin/" + data.IDAdmin, data);

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        // Funcion de Modificar
        public int Editar(AdminEL administrador)
        {
            int r = 0;
            try
            {
                client = new FireSharp.FirebaseClient(config);
                //FirebaseResponse response = client.Set("Admin/" + administrador.IDAdmin, administrador);
                FirebaseResponse response = client.Set("Admin/" + administrador.IDAdmin, administrador);
                return r;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }


        //buscar por id
        public AdminEL FindAdmin(string id)
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Admin/" + id);
            AdminEL data = JsonConvert.DeserializeObject<AdminEL>(response.Body);
            return (data);
        }

        //eliminar
        public int Delete(string id)
        {
            int r = 0;
            try
            {
                client = new FireSharp.FirebaseClient(config);
                FirebaseResponse response = client.Delete("Admin/" + id);
                //FirebaseResponse response = client.Delete("Admin/" + id);

            }
            catch
            {
                r = -1;
            }

            return r;

        }
        //METODO DE LOGIN
        //////////////public void login(AdminEL administrador )
        //////////////{
        //////////////  //  int r = 0;
        //////////////  //{
        //////////////  //  if (string.IsNullOrEmpty (administrador.Email) && string.IsNullOrEmpty  (administrador.Password))
        //////////////  //  {
        //////////////  //      return  r;
        //////////////  //  }
            
        //////////////    ///luego hago el cod de arriba 
        //////////////    ///
        //////////////    FirebaseResponse res = client.Get(@"Admmin/" + administrador.Email);
        //////////////    AdminEL ResAdmin = res.ResultAs<AdminEL>();

        //////////////    AdminEL curAdmin = new AdminEL()
        //////////////    {
        //////////////        Email = Email,
        //////////////        Password = Password
        //////////////    };
        //////////////}
        //private void LoginBtn_Click(object sender, EventArgs e)
        //{
        //    #region Condition
        //    if (string.IsNullOrWhiteSpace(UsernameTbox.Text) &&
        //       string.IsNullOrWhiteSpace(passTbox.Text))
        //    {
        //        MessageBox.Show("Please Fill All The Fields");
        //        return;
        //    }
        //    #endregion

        //    FirebaseResponse res = client.Get(@"Users/" + UsernameTbox.Text);
        //    MyUser ResUser = res.ResultAs<MyUser>();// database result

        //    MyUser CurUser = new MyUser() // USER GIVEN INFO
        //    {
        //        Username = UsernameTbox.Text,
        //        Password = passTbox.Text
        //    };

        //    if (MyUser.IsEqual(ResUser, CurUser))
        //    {
        //        RealApp real = new RealApp();
        //        real.ShowDialog();
        //    }

        //    else
        //    {
        //        MyUser.ShowError();
        //    }
        //}
        //METODO DE LOGIN




        //
    }
}
