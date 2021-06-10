using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Libreta_Contactos.Models
{
    public class Contactos
    {
        [Key]
        public int ContactoId { get; set; }
        
        [Required(ErrorMessage = "Debe ingresar un nombre")]
        public string Nombre { get; set; }
        
        [Required(ErrorMessage = "Debe ingresar un apellido")]
        public string Apellido { get; set; }
        
        [Required(ErrorMessage = "Debe ingresar un número de teléfono")]
        public string Telefono { get; set; }
        
        [Required(ErrorMessage = "Debe ingresar una dirección")]
        public string Direccion { get; set; }
        
        [Required(ErrorMessage = "Debe ingresar un correo electronico")]
        public string Correo { get; set; }
        
        public string Comentario { get; set; }
    }
}
