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
   public class DTLibros
    {


        #region CRUD
        /// <summary>
        /// Consultar todos los proveedores
        /// </summary>
        /// <returns>Retorna una lista con todas los libros</returns>

        public async Task <List<MLibros>> Mostrarlibros()
        {
            try
            {
                return (await FireBaseConnection.FireBase_connect
                    .Child("Libros")
                    .OrderByKey ()
                    .OnceAsync<MLibros>())
                    .Select(datos => new MLibros
                    {
                        ID_LibroFireBase = datos.Key,
                        ID_Libro = datos.Object. ID_Libro,
                        Libro = datos.Object. Libro,
                        Estatus = datos.Object.Estatus,
                        
                    }).ToList();
            }
            catch (Exception ex)
            {
                string mensaje = (ex.StackTrace);
                await App.Current.MainPage.DisplayAlert("Error", "Compruebe la conexión a intenet he intentelo nuevamente.", "Aceptar");
                return null;
            }
        }

        /// <summary>
        /// Insertar Especialidades
        /// </summary>
       /// <param name="obj"></param>
        /// <returns>Retorna True si el registro fue insertado correctamente.</returns>
        public async Task<bool> InsertarLibro(MLibros obj)
        {
            try
            {
                await FireBaseConnection.FireBase_connect
                .Child("Libros")
                .PostAsync(new MLibros()
                {
                    ID_Libro = obj.ID_Libro,
                    Libro = obj.Libro,
                    Estatus= obj.Estatus,
                  
                });
                return true;
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                await App.Current.MainPage.DisplayAlert("Error", mensaje, "Aceptar");
                return false;
            }
        }

        /// <summary>
        /// Modificar Especialidades
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Retorna True si el registro fue modificado correctamente.</returns>



        public async Task<bool> ModificarDatosLibros(MLibros obj)
        {
            try
            {
                var modprov = (await FireBaseConnection.FireBase_connect
                    .Child("Libros")
                    .OnceAsync<MLibros>()).Where(p => p.Object.ID_Libro == obj.ID_Libro).FirstOrDefault();

                
                await FireBaseConnection.FireBase_connect
                    .Child("Libros")
                    .Child(modprov.Key)
                    .PutAsync(new MLibros()
                    {
                        ID_Libro = obj.ID_Libro,
                        Libro = obj.Libro,
                        Estatus = obj.Estatus,
                        
                    });
                return true;
            }
            catch (Exception ex)
            {
                string mensaje = ex.StackTrace;
                //await App.Current.MainPage.DisplayAlert("Error", mensaje, "Aceptar");
                return false;
            }
        }

        /// <summary>
        /// Borrar Especialidad
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Retorna True si el registro fue borrado correctamente.</returns>

        public async Task<bool> BorrarLibros(MLibros obj)
        {
            try
            {
                var borrar = (await FireBaseConnection.FireBase_connect
                    .Child("Libros")
                    .OnceAsync<MLibros>()).Where(p => p.Object.ID_Libro == obj.ID_Libro).FirstOrDefault();
                await FireBaseConnection.FireBase_connect.Child("Libros").Child(borrar.Key).DeleteAsync();
                return true;
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Aceptar");
                return false;
            }
        }

        internal static Task<List<MSocios>> BorrarLibros()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}

