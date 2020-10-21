using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EmergenciasChats.EL
{
    public class AdminEL
    { 

        public Int64 IDAdmin { get; set; }
        //public string IdRol { get; set; }
        //Propiedad de Relacion 
        public string Nombres { get; set; }
        [RegularExpression("^[a-zñáéíóúA-ZÑÁÉÍÓÚ _]*$", ErrorMessage = "Solo se permiten letras")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Apellidos { get; set; }
        [RegularExpression("^[a-zñáéíóúA-ZÑÁÉÍÓÚ _]*$", ErrorMessage = "Solo se permiten letras")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Rol { get; set; } 
        public string Sexo { get; set; }
        public string Dui { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; }  
        public string NameUser { get; set; }
        public string Email { get; set; } 
        //Validacion de datos Email
        [RegularExpression("(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{6,12})$", 
        ErrorMessage = "Limite entre 6 y 12 caracteres, debe contener al menos un número una letra mayúscula y una letra minúscula.")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Password { get; set; }
        //public string Image { get; set; }
        public bool Estado { get; set; }
        //Propiedad de navegacion
        //public Rol Rol { get; set; }


        //

        //ESRE METODO DE ABJ VA EN EL PROYECTO EL
        public static bool IsEqual(AdminEL administrador1, AdminEL administrador2)
        {
            if (administrador1 == null || administrador2 == null) { return false; }

            if (administrador1.NameUser != administrador2.NameUser)
            {

                return false;
            }

            else if (administrador1.Password != administrador1.Password)
            {

                return false;
            }

            return true;
        }
        //
    }
}
