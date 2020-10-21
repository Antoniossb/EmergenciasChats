using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// DtaAnnotations para Validar los campos
using System.ComponentModel.DataAnnotations;

namespace EmergenciasChats.EL
{
   public class UsuarioH
    {
        public Int64 HospitalID { get; set; }
        //Propiedad de Relacion 
        public string Nombre { get; set; }
        [RegularExpression("^[a-zñáéíóúA-ZÑÁÉÍÓÚ _]*$", ErrorMessage = "Solo se permiten letras")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Encargado { get; set; }
        [RegularExpression("^[a-zñáéíóúA-ZÑÁÉÍÓÚ _]*$", ErrorMessage = "Solo se permiten letras")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Rol { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; }
        public string CodigoH { get; set; }
        //public string NameUser { get; set; }
        public string Email { get; set; }
        //Validacion de datos Email
        [RegularExpression("(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{6,12})$",
        ErrorMessage = "Limite entre 6 y 12 caracteres, debe contener al menos un número una letra mayúscula y una letra minúscula.")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Password { get; set; }
        //public string Image { get; set; }
        public bool Estado { get; set; }


    }
}
