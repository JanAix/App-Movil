using Biblioteca.VistaModelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Modelo
{
   public  class MPrestamo:BaseVistaModelo
    {
        public string ID_prestamoFireBase {  get; set; }
        public string ID_prestamo {  get; set; }
        public MLibros ID_Libro {  get; set; }
        public MLibros Libroid {  get; set; }
        public MSocios ID_socio { get; set; }
        public MSocios Socioid {  get; set; }
        public string Fechaprestamo{  get; set; }
        public string Fechadevolucion{  get; set; }    
        public string Estatus { get; set; }
        

    }
}
