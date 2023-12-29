using Biblioteca.Datos;
using Biblioteca.Modelo;
using Biblioteca.Vistas.Tablas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Drawing;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Biblioteca.VistaModelo
{
    public class AgregarSocioVM:BaseVistaModelo
    {

        #region atributo
        public string id_socio;
        public string socio;
        public string estatus;
        public string fecharegistro;
        public bool correrbarra;


        //Botones
        public bool isenebledcrear;
        public bool isenebledmodificar;
        public bool isenebledguardar = true;
        public bool isenebledborrar;
        public bool isenebledcanncelar = true;


        //Otros
        public bool chkestatus;
        public System.Drawing.Color colorfondoid;
        public bool isrefrescar = false;
        public object listasocio;
        public bool isvisible = false;
        #endregion

        #region propiedades

        #region Campos Modelo
        public bool isenebledcancelar = true;

        public string txtidsocio
        {
            get { return id_socio; }
            set { SetValue(ref id_socio, value); }
        }
        public string txtsocio
        {
            get { return socio; }
            set { SetValue(ref socio, value); }
        }
        public string txtestatus
        {
            get { return estatus; }
            set { SetValue(ref estatus, value); }
        }
        public string dtfecharegistro
        {
            get => fecharegistro;
            set { SetValue(ref fecharegistro, value); }
        }

        #endregion

        #region Botones

        public bool IsEnebledCrear
        {
            get { return isenebledcrear; }
            set { SetValue(ref isenebledcrear, value); }
        }
        public bool IsEnebledModificar
        {
            get { return isenebledmodificar; }
            set { SetValue(ref isenebledmodificar, value); }
        }
        public bool IsEnebledGuardar
        {
            get { return isenebledguardar; }
            set { SetValue(ref isenebledguardar, value); }
        }
        public bool IsEnebledCancelar
        {
            get { return isenebledcancelar; }
            set { SetValue(ref isenebledcancelar, value); }
        }
        public bool IsEnebledBorrar
        {
            get { return isenebledborrar; }
            set { SetValue(ref isenebledborrar, value); }
        }
        #endregion

        #region Otros

        public System.Drawing.Color ColorFondoId
        {
            get { return colorfondoid; }
            set { SetValue(ref colorfondoid, value); }
        }
        public bool ChkEstadoValidar
        {
            get { return chkestatus; }
            set { SetValue(ref chkestatus, value); }
        }



        public bool IsRefrescar
        {
            get { return isrefrescar; }
            set { SetValue(ref isrefrescar, value); }
        }
        public object Listasocio
        {
            get { return listasocio; }
            set { SetValue(ref listasocio, value); }
        }
        public bool CorrerBarra
        {
            get { return correrbarra; }
            set { SetValue(ref correrbarra, value); }
        }
        public bool IsVisible
        {
            get { return isvisible; }
            set { SetValue(ref isvisible, value); }
        }
        #endregion

        #endregion

        #region Comandos

        public Command RefrescarCommand { get; }
        public Command CrearCommand { get; }
        public Command ModificarCommand { get; }

        public Command GuardarCambiosCommand { get; }
        public Command CancelarCommand { get; }
        public Command BorrarCommand { get; }
        public Command VolverCommand { get; }
        #endregion

        #region Metodos

        //Creamos una instancia de:
        DTLibros db = new DTLibros();
        DTSocios dbsocio = new DTSocios();
        //DBAlmacenes dbalmacen = new DBAlmacenes();

        public ObservableCollection<MSocios> socioscollection = new ObservableCollection<MSocios>();

        private async Task TestListViewBindingAsync()
        {

            var lista = new List<MSocios>();
            {
                var funcion = new DTSocios();
                lista = await funcion.MostrarSocio();

            }
            foreach (var item in lista)
            {
                socioscollection.Add(item);
            }

        }


        public async Task MostrarSocio()
        {
            IsRefrescar = true;
            await Task.Delay(100);
            Listasocio = await dbsocio.MostrarSocio();
            IsRefrescar = false;
        }
        public async Task Buscar_En_DBSocio()
        {
            List<MSocios> Listprov = await dbsocio.MostrarSocio();
            foreach (var encontrado in Listprov)
            {
                socioscollection.Add(encontrado);
            }
        }

        public async Task Crear()
        {
            List<MSocios> registros = await dbsocio.MostrarSocio();
            int cant_registros = registros.Count();
            int IdGenerado;

            if (cant_registros == 0)
                IdGenerado = 1;
            else
                IdGenerado = cant_registros + 1;

            txtidsocio = string.Format("S{0:000}", IdGenerado);
            txtsocio = "";
            txtestatus = "";
            _ = dtfecharegistro;


            ColorFondoId = System.Drawing.Color.LightGreen;
            IsEnebledModificar = false;
            IsEnebledCrear = true;
            IsEnebledBorrar = false;
            IsEnebledCancelar = true;
            IsEnebledGuardar = true;
        }
        public async Task GuardarCambios()
        {
            try
            {

                if (ColorFondoId == System.Drawing.Color.Transparent)
                {
                    await App.Current.MainPage.DisplayAlert("Información", "No existen datos que guardar.", "Aceptar");
                    return;
                }
                #region Reglas para la insercion de los datos
                if (string.IsNullOrEmpty(txtsocio))
                {
                    await App.Current.MainPage.DisplayAlert("Advertencia", "Debe de indicar un socio.", "Aceptar");
                    return;
                }
                if (ChkEstadoValidar == true)
                    estatus = "Inactivo";
                else
                    estatus = "Activo";
                #endregion

                //Instanciamos el modelo para obtener los datos introducidos por el usuario
                var obj = new MSocios
                {
                    ID_socio = id_socio,
                    Nombre = socio ,
                    Estatus = estatus,
                    Fecharegistro= fecharegistro

                };

                if (ColorFondoId == System.Drawing.Color.LightGreen)
                {
                    if (obj.Estatus == "Inactivo")
                    {
                        await App.Current.MainPage.DisplayAlert("Advertencia", "No puede insertar como inactivo.", "Aceptar");
                    }
                    else
                    {
                        CorrerBarra = true;
                        IsVisible = true;
                        await Task.Delay(1000);

                        await dbsocio.InsertarSocio(obj);

                        CorrerBarra = false;
                        IsVisible = false;
                        ColorFondoId = System.Drawing.Color.Transparent;
                        IsEnebledCancelar = false;
                        IsEnebledGuardar = false;
                        IsEnebledCrear = true;
                        IsEnebledModificar = true;
                        IsEnebledBorrar = true;
                        await App.Current.MainPage.DisplayAlert("Información", "Datos registrados exitosamente.", "Aceptar");
                        await Navigation.PopAsync();

                    }
                }
                else
                {
                    CorrerBarra = true;
                    IsVisible = true;
                    await Task.Delay(1000);

                    bool respuesta = await dbsocio.ModificarDatosSocio(obj);

                    CorrerBarra = false;
                    IsVisible = false;
                    if (respuesta == true)
                    {
                        ColorFondoId = System.Drawing.Color.Orange;
                        IsEnebledCancelar = false;
                        IsEnebledGuardar = false;
                        IsEnebledCrear = true;
                        IsEnebledModificar = true;
                        IsEnebledBorrar = true;
                        await App.Current.MainPage.DisplayAlert("Información", "Datos modificados exitosamente.", "Aceptar");
                        await App.Current.MainPage.Navigation.PopAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                await App.Current.MainPage.DisplayAlert("Advertencia", (ex.StackTrace), "Aceptar");
            }
        }


        public async Task Modificar()
        {
            var obj = new MSocios
            {
                ID_socio = id_socio,
                Nombre = socio,
                Estatus = estatus,
                Fecharegistro = fecharegistro,
            };


            await dbsocio.ModificarDatosSocio(obj);




        }

        public async Task Borrar()
        {
            try
            {
                List<MSocios> ListEspObtenida = await dbsocio.MostrarSocio();
                var objsocio = new MSocios()
                {
                    ID_socio = id_socio
                };

                if (string.IsNullOrEmpty(txtidsocio))
                {
                    await App.Current.MainPage.DisplayAlert("Información", "Debe seleccionar un socio.", "Aceptar");
                }
                else
                {
                    string respuesta = await App.Current.MainPage.DisplayActionSheet("¿Seguro que desea borrar este socio?", "Cancelar", null, "Si", "No");
                    if (respuesta == "Si")
                    {
                        bool relacion = ListEspObtenida.Select(r => r.ID_socio == objsocio.ID_socio).FirstOrDefault();
                        if (relacion == true)
                        {
                            await App.Current.MainPage.DisplayAlert("Advertecia", "No se puede borrar un socio que esté relacionado a un libro.", "Aceptar");
                        }
                        else
                        {
                            CorrerBarra = true;
                            IsVisible = true;
                            await Task.Delay(1000);

                            await dbsocio.BorrarSocio(objsocio);

                            CorrerBarra = false;
                            IsVisible = false;
                            ColorFondoId = System.Drawing.Color.Transparent;
                            ChkEstadoValidar = false;
                            IsEnebledCancelar = false;
                            IsEnebledGuardar = false;
                            await App.Current.MainPage.DisplayAlert("Información", "Datos borrados exitosamente.", "Aceptar");

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Aceptar");
            }
        }

        public void Cancelar()
        {
            if (ColorFondoId == System.Drawing.Color.LightGreen)
            {
                txtidsocio = "";
                txtsocio = "";
                txtestatus = "";
                _=fecharegistro;
                ColorFondoId = System.Drawing.Color.Transparent;
                IsEnebledCancelar = false;
                IsEnebledGuardar = false;
                IsEnebledBorrar = true;
                IsEnebledModificar = true;
                IsEnebledCrear = true;
            }
            else
            {
                ColorFondoId = System.Drawing.Color.Transparent;
                IsEnebledCancelar = false;
                IsEnebledGuardar = false;
                IsEnebledBorrar = true;
                IsEnebledModificar = true;
                IsEnebledCrear = true;
            }
        }
        //public List<OpcionCombo> DatosEstado()
        //{
        //    var estado = new List<OpcionCombo>()
        //    {
        //        new OpcionCombo(){ IdPos = 0, Texto="Activo" },
        //        new OpcionCombo(){ IdPos = 1, Texto ="Inactivo" }
        //    };
        //    return estado;
        //}

        public async Task NavegarAgregar()
        {
            await Navigation.PushAsync(new AgregarS());
            //await Navigation.PushAsync(new EspecialidadMaestra());

        }


        public async Task Ir_CrearLibros()
        {
            // await Navigation.PushAsync(new ());
            await Navigation.PushAsync(new ListaLibros());
            _ = Crear();
        }
        public async Task Volver()
        {
            try
            {
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Aceptar");
            }

        }

        #endregion

        #region Constructor

        public AgregarSocioVM(INavigation navegar)
        {
            Navigation = navegar;


            NavegarAgregarcommand = new Command(async () => await NavegarAgregar());
            //Controlar estados al iniciar el componente
            ColorFondoId = System.Drawing.Color.Transparent;

            IsEnebledGuardar = false;
            IsEnebledCancelar = false;
            IsEnebledCrear = true;
            IsEnebledModificar = false;
            IsEnebledBorrar = false;

            RefrescarCommand = new Command(async () => await MostrarSocio());
            CrearCommand = new Command(async () => await Crear());
            GuardarCambiosCommand = new Command(async () => await GuardarCambios());
            //ModificarCommand = new Command(async () => await GuardarCambios());

            CancelarCommand = new Command(async () => Cancelar());
            BorrarCommand = new Command(async () => await Borrar());
            VolverCommand = new Command(async () => await Volver());


            //este va
            //Ir_CrearProveedorCommand = new Command(async () => await Ir_CrearProveedor());


            //PkEstado = DatosEstado().OrderBy(e => e.Texto).ToList();
            _ = MostrarSocio();
            _ = TestListViewBindingAsync();
            _ = Crear();
            //Buscar_En_DBProveedores();
        }

        //Creamos un segundo constructor de la misma clase, para poder cargar los datos seleccionados en la clase ListaProveedores.xaml.cs
        public AgregarSocioVM(MSocios obj)
        {
            //Cargar datos del id seleccionado
            txtidsocio = obj.ID_socio;
            txtsocio = obj.Nombre;
            txtestatus = obj.Estatus;
            dtfecharegistro=obj.Fecharegistro;

            if (obj.Estatus == "Inactivo")
                ChkEstadoValidar = true;
            else
                ChkEstadoValidar = false;

            //Controlar estados al iniciar el componente
            ColorFondoId = System.Drawing.Color.Orange;
            IsEnebledGuardar = false;
            IsEnebledCancelar = false;
            IsEnebledCrear = true;
            IsEnebledModificar = true;
            IsEnebledBorrar = true;
            CrearCommand = new Command(async () => await Crear());
            GuardarCambiosCommand = new Command(async () => await GuardarCambios());
            ModificarCommand = new Command(async () => await Modificar());
            CancelarCommand = new Command(async () => Cancelar());
            BorrarCommand = new Command(async () => await Borrar());
            VolverCommand = new Command(async () => await Volver());
            //PkEstado = DatosEstado().OrderBy(e => e.Texto).ToList();
            _ = MostrarSocio();
        }

        public AgregarSocioVM(INavigation navigation,
        MSocios esp = null)
        {

            txtidsocio = esp.ID_socio;
            txtsocio= esp.Nombre;
            txtestatus = esp.Estatus;
            dtfecharegistro = esp.Fecharegistro;
        }



        public Command NavegarAgregarcommand { get; }




        #endregion
    }
}
