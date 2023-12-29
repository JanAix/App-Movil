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
    public class DTSocios
    {
        #region CRUD
        /// <summary>
        /// Consultar todos los medicos
        /// </summary>
        /// <returns>Retorna una lista con todos los medicos.</returns>
        public async Task<List<MSocios>> MostrarSocio()
        {
            try
            {
                return (await FireBaseConnection.FireBase_connect
                    .Child("Socios")
                    .OrderByKey()
                    .OnceAsync<MSocios>())
                    .Select(datos => new MSocios
                    {
                        ID_socioFireBase = datos.Key,
                        ID_socio = datos.Object.ID_socio,
                        Nombre = datos.Object.Nombre,
                        Estatus = datos.Object.Estatus,
                        Fecharegistro = datos.Object.Fecharegistro,





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
        /// <param name="obj"></param>
        /// <returns>Retorna True si el registro fue insertado correctamente.</returns>
        public async Task<bool> InsertarSocio(MSocios obj)
        {
            try
            {
                await FireBaseConnection.FireBase_connect
                .Child("Socios")
                .PostAsync(new MSocios()
                {
                    ID_socio = obj.ID_socio,
                    Nombre = obj.Nombre,
                    Estatus = obj.Estatus,
                    Fecharegistro = obj.Fecharegistro,





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
        /// <param name="obj"></param>
        /// <returns>Retorna True si el registro fue modificado correctamente.</returns>
        public async Task<bool> ModificarDatosSocio(MSocios obj)
        {
            try
            {
                var modalm = (await FireBaseConnection.FireBase_connect
                    .Child("Socios")
                    .OnceAsync<MSocios>()).Where(p => p.Object.ID_socio == obj.ID_socio).FirstOrDefault();
                await FireBaseConnection.FireBase_connect
                    .Child("Socios")
                    .Child(modalm.Key)
                    .PutAsync(new MSocios()
                    {
                        ID_socio = obj.ID_socio,
                        Nombre = obj.Nombre,
                        Estatus = obj.Estatus,
                        Fecharegistro =obj.Fecharegistro,



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
        /// <param name="obj"></param>
        /// <returns>Retorna True si el registro fue borrado correctamente.</returns>
        public async Task<bool> BorrarSocio(MSocios obj)
        {
            try
            {
                var borrar = (await FireBaseConnection.FireBase_connect
                    .Child("Socios")
                    .OnceAsync<MSocios>()).Where(p => p.Object.ID_socio == obj.ID_socio).FirstOrDefault();
                await FireBaseConnection.FireBase_connect.Child("Socios").Child(borrar.Key).DeleteAsync();
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
