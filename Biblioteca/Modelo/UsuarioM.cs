using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;
namespace Biblioteca.Modelo
{
   public class UsuarioM
    {

        public string IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }
        public string Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}

