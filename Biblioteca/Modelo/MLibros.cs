using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Modelo
{
    public class MLibros
    {


        public string ID_LibroFireBase { get; set; }
        public string ID_Libro { get; set; }
        public string Libro { get; set; }
        public string Estatus { get; set; }
        public string Libroid => $"{ID_Libro}-{Libro}";

        public static implicit operator MLibros(string v)
        {
            throw new NotImplementedException();
        }
    }
  }

