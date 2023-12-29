using Biblioteca.Conexion;
using Biblioteca.Modelo;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Datos
{
    public class DTPrestamos
    {
        #region CRUD
        /// <summary>
        /// Consultar todos los medicos
        /// </summary>
        /// <returns>Retorna una lista con todos los prestamos.</returns>
        public async Task<List<MPrestamo>> ListarPrestamo()
        {
            try
            {
                return (await FireBaseConnection.FireBase_connect
                    .Child("Prestamos")
                    .OrderByKey()
                    .OnceAsync<MPrestamo>())
                    .Select(datos => new MPrestamo
                    {
                        ID_prestamoFireBase = datos.Key,
                        ID_prestamo = datos.Object.ID_prestamo,
                        Fechaprestamo = datos.Object.Fechaprestamo,
                        Fechadevolucion = datos.Object.Fechadevolucion,
                        Estatus = datos.Object.Estatus,
                        ID_Libro= datos.Object.Libroid,
                        ID_socio=datos.Object.Socioid
                        
                        //ID_socio = new MSocios
                        //{

                        //    ID_socio = datos.Object.ID_socio.ID_socio,
                        //   // socioid = datos.Object.ID_socio.ID_socio
                        //},

                        //ID_Libro = new MLibros
                        //{
                        //    ID_Libro = datos.Object.ID_Libro.ID_Libro,

                        //},

                    }).ToList();
            }
            catch (Exception)
            {
                return null;
                await App.Current.MainPage.DisplayAlert("Error", "Compruebe la conexión a intenet he intentelo nuevamente.", "Aceptar");

            }
        }

        /// <summary>
        /// Insertar Medicos
        /// </summary>
        /// <param name="objsocio"></param>
        /// <returns>Retorna True si el registro fue insertado correctamente.</returns>
        public async Task<bool> InsertarPrestamo(MPrestamo objprestamo)
        {
            try
            {
                await FireBaseConnection.FireBase_connect
                .Child("Prestamos")
                .PostAsync(new MPrestamo()
                {
                    ID_prestamo = objprestamo.ID_prestamo,
                     Fechaprestamo= objprestamo.Fechaprestamo,
                    Fechadevolucion = objprestamo.Fechadevolucion,
                    Estatus= objprestamo.Estatus,
                    //ID_socio= objprestamo.Socioid,
                    //ID_Libro= objprestamo.Libroid,


                    ID_socio = new MSocios
                    {


                        ID_socio = objprestamo.ID_socio.ID_socio,
                        Nombre = objprestamo.ID_socio.Nombre,


                    },

                    ID_Libro = new MLibros
                    {


                        ID_Libro = objprestamo.ID_Libro.ID_Libro,
                        Libro = objprestamo.ID_Libro.Libro
                    },

                    
                });
                return true;
            }
            catch (Exception ex)
            {
                return false;
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Aceptar");
            }
        }

        /// <summary>
        /// Modificar Medicos
        /// </summary>
        /// <param name="objprestamos"></param>
        /// <returns>Retorna True si el registro fue modificado correctamente.</returns>
        public async Task<bool> ModificarDatosPrestamo(MPrestamo objprestamos)
        {
            try
            {
                var modalm = (await FireBaseConnection.FireBase_connect
                    .Child("Prestamos")
                    .OnceAsync<MPrestamo>()).Where(p => p.Object.ID_prestamo == objprestamos.ID_prestamo).FirstOrDefault();
                await FireBaseConnection.FireBase_connect
                    .Child("Prestamos")
                    .Child(modalm.Key)
                    .PutAsync(new MPrestamo()
                    {
                        ID_prestamo = objprestamos.ID_prestamo,
                        Fechaprestamo = objprestamos.Fechaprestamo,
                        Fechadevolucion = objprestamos.Fechadevolucion,
                        Estatus = objprestamos.Estatus,
                        ID_Libro= objprestamos.Libroid,
                        ID_socio= objprestamos.Socioid
                        //ID_Libro= new MLibros
                        //{
                        //    //ID_Libro= objprestamos.ID_Libro.ID_Libro,
                        //    ID_Libro= objprestamos.ID_Libro.Libroid
                        //},

                        //ID_socio = new MSocios
                        //{
                        //    ID_socio= objprestamos.ID_socio.ID_socio,
                           
                        //},
                        
                    });
                return true;
            }
            catch (Exception ex)
            {
                return false;
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Aceptar");
            }
        }

        /// <summary>
        /// Borrar Medicos
        /// </summary>
        /// <param name="objprestamos"></param>
        /// <returns>Retorna True si el registro fue borrado correctamente.</returns>
        public async Task<bool> BorrarPrestamo(MPrestamo objprestamos)
        {
            try
            {
                var borrar = (await FireBaseConnection.FireBase_connect
                    .Child("Prestamos")
                    .OnceAsync<MPrestamo>()).Where(p => p.Object.ID_prestamo == objprestamos.ID_prestamo).FirstOrDefault();
                await FireBaseConnection.FireBase_connect.Child("Prestamos").Child(borrar.Key).DeleteAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Aceptar");
            }
        }

        #endregion

    }
}



    
