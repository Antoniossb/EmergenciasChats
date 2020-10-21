using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//referencias de proyecto EL
using EmergenciasChats.EL;
// configurar firebase     
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;



namespace EmergenciasChats.DAL
{
   public class UsuarioHDAL
    {
        // Instancia de config de firebase
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "CPT7izztGnLhDZ8RFM3lfSiJxLOxsAf6UnrERsOd",
            BasePath = "https://aplicacion-web-de-emergencias.firebaseio.com/"


        };
        //establecer conexion a firebase message de error and exit
        IFirebaseClient client;
       

//Metodo de guardar
public int Guarda(UsuarioH usuarioH)
        {

            int r = 1;
            if ((usuarioH.Nombre != null) && (usuarioH.Encargado != null) && (usuarioH.Rol != null) && (usuarioH.Telefono > 0)
                && (usuarioH.Direccion != null) && (usuarioH.CodigoH != null) && (usuarioH.Email != null) && (usuarioH.Password != null))
            {
                AddUsuarioHToFirebase(usuarioH);
                return r;
            }             
            else
            {
                return 0;
            }

        }


        //metodo get  lista
        public List<UsuarioH> ListAUsuario()
        {

            {
                client = new FireSharp.FirebaseClient(config);
                FirebaseResponse response = client.Get("Hospital");
                dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);

                var list = new List<UsuarioH>();
                foreach (var item in data)
                {
                    list.Add(JsonConvert.DeserializeObject<UsuarioH>(((JProperty)item).Value.ToString()));
                }
                return (list);   
            }
        }




        //metodo de guardar 
        public void AddUsuarioHToFirebase(UsuarioH usuarioH)
        {

            try
            {
                client = new FireSharp.FirebaseClient(config);
                var data = usuarioH;
                PushResponse response = client.Push("Hospital/", data);
               // data.HospitalID = response.Result.name;
                SetResponse setResponse = client.Set("Hospital/" + data.HospitalID, data);
                //

            }
            catch (Exception ex) 
            {
                throw ex;
            }


        }

    

        // Funcion de Modificar
        public int Modificar(UsuarioH usuarioH)
        {
            int r = 0;
            try
            {
                client = new FireSharp.FirebaseClient(config);
                FirebaseResponse response = client.Set("Hospital/" + usuarioH.HospitalID, usuarioH);
                return r;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }















        //buscar por id
        public UsuarioH FindUsuarioH(string id)
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Hospital/" + id);
            UsuarioH data = JsonConvert.DeserializeObject<UsuarioH>(response.Body);
            return (data);
        }

        //eliminar
        public int Delete(string id)
        {
            int r = 0;
            try
            {
                client = new FireSharp.FirebaseClient(config);
                FirebaseResponse response = client.Delete("Hospital/" + id);
                //FirebaseResponse response = client.Delete("Admin/" + id);

            }
            catch
            {
                r = -1;
            }

            return r;

        }
    }
}
