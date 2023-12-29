using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Biblioteca.Modelo
{
    public class MSocios
    {


        public string ID_socioFireBase { get; set; }
        public string ID_socio { get; set; }
        public string Nombre { get; set; }
        public string Fecharegistro { get; set; }
        public string Estatus { get; set; }
        public MLibros Libro { get; internal set;}
        public string Socioid => $"{ID_socio}-{Nombre}";

        public static implicit operator MSocios(string v)
        {
            throw new NotImplementedException();
        }
    }
}
