using Biblioteca.Datos;
using Biblioteca.Modelo;
using Biblioteca.Vistas.MenuPrincipal0;
using Biblioteca.Vistas.Tablas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Biblioteca.VistaModelo
{
    public class AgregarPrestamosVM : BaseVistaModelo
    {

        #region Atributos
        //Campos Modelo
        MSocios selectSocio;
        public List<MSocios> listasocios = new List<MSocios>();
        MLibros selectLibro;
        public List<MLibros> listalibros = new List<MLibros>();
        public string idprestamo;
        public string idsocio;
        public string nombre;
        public string fechaprestamo;
        public string fechadevolucion;
        public string estatus;
        public string idlibro;
        public string libro;
        public MLibros Libroid;
        public MSocios Socioid;
       


        //Botones
        public bool isenebledcrear;
        public bool isenebledmodificar;
        public bool isenebledguardar;
        public bool isenebledcancelar;
        public bool isenebledborrar;
        public bool isvisiblelistalibro = false;
        public bool isvisiblebuscarlibro = false;
        public bool isvisiblelistasocio = false;
        public bool isvisiblebuscarsocio = false;

        //Otros
        public bool chkestado;
        public System.Drawing.Color colorfondoid;
        public bool isrefrescar = false;
        public object listasocio;
        public object listalibro;
        public object listaprestamo;
        //public bool correrbarra;
        public bool isvisible = false;
        #endregion

        #region Propiedades


        #region Campos Modelo

        public List<MLibros> ListaLibro
        {
            get { return listalibros; }
            set { SetValue(ref listalibros, value); }
        }

        public MLibros SelectLibro
        {
            get { return selectLibro; }
            set
            {
                SetProperty(ref selectLibro, value);
                txtidlibro = selectLibro.ID_Libro;
                txtlibro=selectLibro.Libro;

            }
        }

        public List<MSocios> ListaSocio
        {
            get { return listasocios; }
            set { SetValue(ref listasocios, value); }
        }

        public MSocios SelectSocio
        {
            get { return selectSocio; }
            set
            {
                SetProperty(ref selectSocio, value);
                txtidsocio = selectSocio.ID_socio;
                txtnombre = selectSocio.Nombre;

            }
        }



        public string txtidprestamo
        {
            get { return idprestamo; }
            set { SetValue(ref idprestamo, value); }
        }

        public string txtidsocio
        {
            get { return idsocio; }
            set { SetValue(ref idsocio, value); }
        }


        public string txtnombre
        {
            get { return nombre; }
            set { SetValue(ref nombre, value); }
        }



        public string txtidlibro
        {
            get { return idlibro; }
            set { SetValue(ref idlibro, value); }
        }
        public string txtlibro
        {

            get
            {
                return libro;
            }
            set { SetValue(ref libro, value); }
        }



        public string txtfechaprestamo
        {
            get { return fechaprestamo; }
            set { SetValue(ref fechaprestamo, value); }
        }

        public string txtfechadevolucion
        {
            get { return fechadevolucion; }
            set { SetValue(ref fechadevolucion, value); }
        }

        public string txtestatus
        {
            get { return estatus; }
            set { SetValue(ref estatus, value); }
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

        public Command NavegarAgregarCommand { get; }

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
        public bool IsVisibleListaLibro
        {
            get { return isvisiblelistalibro; }
            set { SetValue(ref isvisiblelistalibro, value); }
        }
        public bool IsVisibleBuscarEspecialidades
        {
            get { return isvisiblebuscarlibro; }
            set { SetValue(ref isvisiblebuscarlibro, value); }
        }
        public bool IsVisibleListaSocio
        {
            get { return isvisiblelistasocio; }
            set { SetValue(ref isvisiblelistasocio, value); }
        }
        public bool IsVisibleBuscarSocio
        {
            get { return isvisiblebuscarsocio; }
            set { SetValue(ref isvisiblebuscarsocio, value); }
        }
        #endregion

        #region Otros
        public bool ChkEstadoValidar
        {
            get { return chkestado; }
            set { SetValue(ref chkestado, value); }
        }

      

        public System.Drawing.Color ColorFondoId
        {
            get { return colorfondoid; }
            set { SetValue(ref colorfondoid, value); }
        }
        public bool IsRefrescar
        {
            get { return isrefrescar; }
            set { SetValue(ref isrefrescar, value); }
        }
        public object ListaLibros
        {
            get { return listalibro; }
            set { SetValue(ref listalibro, value); }
        }
        public object ListaSocios
        {
            get { return listasocio; }
            set { SetValue(ref listasocio, value); }
        }

        public object ListaPrestamos
        {
            get { return listaprestamo; }
            set { SetValue(ref listaprestamo, value); }
        }


        public bool IsVisible
        {
            get { return isvisible; }
            set { SetValue(ref isvisible, value); }
        }
        #endregion

        #endregion

        #region Command
        public Command RefrescarCommand { get; }
        public Command RefrescarListMedCommand { get; }
        public Command CrearCommand { get; }
        public Command ModificarCommand { get; }
        public Command GuardarCambiosCommand { get; }
        public Command CancelarCommand { get; }
        public Command BorrarCommand { get; }
        public Command Ir_CrearMedicoCommand { get; }
        public Command BuscarEspecialidadCommand { get; }
        public Command CerrarListaEspecialidadesCommand { get; }
        public Command VolverCommand { get; }
        
        #endregion

        #region Métodos
        //Creamos una instancia de:
        DTPrestamos dbprestamo = new DTPrestamos();
        DTLibros dblibro = new DTLibros();
        DTSocios dbsocio = new DTSocios();
        public ObservableCollection<MPrestamo> Coleccionprestamos = new ObservableCollection<MPrestamo>();
        

        private async Task MostrarLibros()
        {
            var funcion = new DTLibros();
            ListaLibro = await funcion.Mostrarlibros();
        }

        private async Task MostrarSocio()
        {
            var funcion = new DTSocios();
            ListaSocio = await funcion.MostrarSocio();

        }

        public async Task ListarPrestamo()
        {
            IsRefrescar = true;
            await Task.Delay(100);
            ListaPrestamos = await dbprestamo.ListarPrestamo();
           IsRefrescar=true;
        }

        public async Task Listar_Libro()
        {
            IsRefrescar = true;
            await Task.Delay(100);
            ListaLibro = await dblibro.Mostrarlibros();
            IsRefrescar = false;
        }
        public async Task Listar_Socio()
        {
            IsRefrescar = true;
            await Task.Delay(100);
            ListaSocio = await dbsocio.MostrarSocio();
            IsRefrescar = false;
        }
        public async Task Buscar_En_DTPrestamo()
        {
            List<MPrestamo> ListPres = await dbprestamo.ListarPrestamo();
            foreach (var encontrado in ListPres)
            {
                Coleccionprestamos.Add(encontrado);
            }
        }
        public async Task Crear()
        {
            List<MPrestamo> registros = await dbprestamo.ListarPrestamo();
            int cant_registros = registros.Count();
            int IdGenerado;
            if (cant_registros == 0)
                IdGenerado = 1;
            else
                IdGenerado = cant_registros + 1;

            txtidprestamo = string.Format("Pr{0:000}", IdGenerado);
           
           
            txtfechadevolucion = DateTime.Now.Date.ToString("dd-MMM-yyy");
            txtestatus = "";
            txtfechaprestamo = DateTime.Now.Date.ToString("dd-MMM-yyy");
            
            ColorFondoId = System.Drawing.Color.LightGreen;
            IsEnebledModificar = false;
            IsEnebledCrear = false;
            IsEnebledCancelar = true;
            IsEnebledGuardar = true;
            IsEnebledBorrar = false;
           
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
                if (string.IsNullOrEmpty(txtfechaprestamo))
                {
                    await App.Current.MainPage.DisplayAlert("Advertencia", "Debe de indicar una fecha.", "Aceptar");
                    return;
                }
               
                if (string.IsNullOrEmpty(txtfechadevolucion))
                {
                    await App.Current.MainPage.DisplayAlert("Advertencia", "Debe de colocar una fecha para la devolucion.", "Aceptar");
                    return;
                }
                if (txtidsocio == "")
                {
                    await App.Current.MainPage.DisplayAlert("Advertencia", "Debe de colocar el id ", "Aceptar");
                    return;
                }
                //Validar estado
                if (ChkEstadoValidar == true)
                    estatus = "Prestado";
                else
                    estatus = "Devuelvo";
                #endregion

                //Instanciamos el modelo para obtener los datos introducidos por el usuario
               // await App.Current.MainPage.DisplayAlert("Advertencia", idsocio, "Aceptar");
                //await App.Current.MainPage.DisplayAlert("Advertencia", idlibro, "Aceptar");
                var objprestamos = new MPrestamo
                {
                    ID_prestamo = idprestamo,
                    Fechaprestamo = fechaprestamo,
                    Fechadevolucion = fechadevolucion,
                    Estatus = estatus,
                    ID_socio = new MSocios
                    {

                        ID_socio = idsocio
                    },

                    ID_Libro = new MLibros
                    {
                        ID_Libro = idlibro

                    }
                };

                if (ColorFondoId == System.Drawing.Color.LightGreen)
                {
                    if (objprestamos.Estatus == "Inactivo")
                    {
                        await App.Current.MainPage.DisplayAlert("Advertencia", "No se puede insertar un prestamo como inactivo.", "Aceptar");
                    }
                    else
                    {
                        IsVisible = true;
                        await Task.Delay(1000);
                        await dbprestamo.InsertarPrestamo(objprestamos);
                        IsVisible = false;
                        ColorFondoId = System.Drawing.Color.Transparent;
                        IsEnebledCancelar = false;
                        IsEnebledGuardar = false;
                        IsEnebledCrear = true;
                        IsEnebledModificar = true;
                        IsEnebledBorrar = true;
                        await App.Current.MainPage.DisplayAlert("Información", "Datos registrados exitosamente.", "Aceptar");
                        await App.Current.MainPage.Navigation.PopAsync();

                    }
                }
                else

                {
                    IsVisible = true;
                    await Task.Delay(1000);
                    bool respuesta = await dbprestamo.ModificarDatosPrestamo(objprestamos);
                    IsVisible = false;
                    if (respuesta == true)
                    {
                        ColorFondoId = System.Drawing.Color.Transparent;
                        IsEnebledCancelar = false;
                        IsEnebledGuardar = false;
                        IsEnebledCrear = true;
                        IsEnebledModificar = true;
                        IsEnebledBorrar = true;
                        await App.Current.MainPage.DisplayAlert("Información", "Datos modificados exitosamente.", "Aceptar");
                     
                    }
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Aceptar");
            }
        }
        public async Task Modificar()
        {

            var objprestamos = new MPrestamo
            {
                ID_prestamo = idprestamo,
                Fechadevolucion = fechadevolucion,
                Fechaprestamo = fechaprestamo,
                ID_Libro= idlibro,
                ID_socio= idsocio,
                
            };


            await dbprestamo.ModificarDatosPrestamo(objprestamos);




            try
            {
                List<MPrestamo> cargardatos = await dbprestamo.ListarPrestamo();
                var obj = new MPrestamo
                {
                    ID_prestamo = idprestamo
                };
                var datosencontrados = cargardatos.Where(buscar => buscar.ID_prestamo == objprestamos.ID_prestamo).FirstOrDefault();
                if (datosencontrados != null)
                {

                    txtidprestamo = datosencontrados.ID_prestamo;
                   
                    txtestatus = datosencontrados.Estatus;
                    txtidlibro= datosencontrados.ID_Libro.ID_Libro;
                    txtidsocio = datosencontrados.ID_socio.ID_socio;

                    
                    ColorFondoId = System.Drawing.Color.Khaki;
                    IsEnebledModificar = false;
                    IsEnebledCrear = false;
                    IsEnebledCancelar = true;
                    IsEnebledGuardar = true;
                    IsEnebledBorrar = false;
                   
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Información", "Debe seleccionar un prestamo", "Aceptar");
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Aceptar");
            }
        }
        public async Task Borrar()
        {
            try
            {
                var objprestamos = new MPrestamo()
                {
                    ID_prestamo = idprestamo
                };

                if (string.IsNullOrEmpty(txtidprestamo))
                {
                    await App.Current.MainPage.DisplayAlert("Información", "Debe de seleccionar un prestamo.", "Aceptar");
                }
                else
                {
                    string respuesta = await App.Current.MainPage.DisplayActionSheet("¿Seguro que desea borrar el Prestamo?", "Cancelar", null, "Si", "No");
                    if (respuesta == "Si")
                    {
                        IsVisible = true;
                        await Task.Delay(1000);
                        await dbprestamo.BorrarPrestamo(objprestamos);
                        IsVisible = false;

                        txtidprestamo = "";
                        txtidlibro= "";
                        txtidsocio = "";
                        txtestatus = "";
                        txtfechaprestamo = "";
                        txtfechadevolucion = "";
                        

                        ChkEstadoValidar = false;
                        IsEnebledCancelar = false;
                        IsEnebledGuardar = false;
                        ColorFondoId = System.Drawing.Color.Transparent;
                        await App.Current.MainPage.DisplayAlert("Información", "Datos borrados exitosamente.", "Aceptar");
                        await Navigation.PushModalAsync(new Repote());

                    }
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Aceptar");
            }
        }

        public async Task Cancelar()
        {
            if (ColorFondoId == System.Drawing.Color.LightGreen)
            {
                txtidprestamo = "";
                txtidlibro = "";
                txtidsocio = "";
                txtestatus = "";
                txtfechaprestamo = "";
                txtfechadevolucion = "";
                

                ColorFondoId = System.Drawing.Color.Transparent;
                IsEnebledCancelar = false;
                IsEnebledGuardar = false;
                IsVisibleBuscarEspecialidades = false;
                IsEnebledModificar = true;
                IsEnebledCrear = true;
                IsEnebledBorrar = true;
            }
            else
            {
                ColorFondoId = System.Drawing.Color.Transparent;
                IsEnebledCancelar = false;
                IsEnebledGuardar = false;
                IsVisibleBuscarEspecialidades = false;
                IsEnebledModificar = true;
                IsEnebledCrear = true;
                IsEnebledBorrar = true;
            }
        }


        public async Task Volver()
        {
            await Navigation.PopAsync();
        }

        public async Task Irprestamo()
        {
            await Navigation.PushAsync(new AgregarP());


        }

        public async Task CerrarListaLibro()
        {
            isvisiblelistalibro = false;
        }
        public async Task CerrarListaSocio()
        {
            isvisiblelistasocio = false;
        }

        async public Task BuscarLibro()
        {
            isvisiblelistalibro = true;
            _ = Listar_Libro();
            //return Task.CompletedTask;
        }
        async public Task BuscarSocio()
        {
            isvisiblelistalibro = true;
            _ = Listar_Socio();
            //return Task.CompletedTask;
        }

       

        #endregion

        #region Constructor

        //Principal
        public AgregarPrestamosVM (INavigation navegar)
        {
            Navigation = navegar;

            AgregarPrestamocommand = new Command (async () =>  await Irprestamo ());

            //Controlar estados de los botones al iniciar el componente
            ColorFondoId = System.Drawing.Color.Transparent;
            IsEnebledGuardar = false;
            IsEnebledCrear = true;
            IsEnebledModificar = true;
            IsEnebledBorrar = true;
            IsEnebledCancelar = false;
            //egerman
            //IsVisibleBuscarLibro = false;
           // isvisiblelistaespecialidades = false;

            RefrescarCommand = new Command(async () => await ListarPrestamo());
         
            CrearCommand = new Command(async () => await Crear());
            GuardarCambiosCommand = new Command(async () => await GuardarCambios());
            ModificarCommand = new Command(async () => await Modificar());
            BorrarCommand = new Command(async () => await Borrar());
            CancelarCommand = new Command(async () => await Cancelar());
          
            VolverCommand = new Command(async () => await Volver());
         
          
            _ = Listar_Libro();
            _ = MostrarLibros();
            _ = Listar_Socio();
            _= MostrarSocio();
        }


        public AgregarPrestamosVM (MPrestamo objprestamos)
        {

         

            //Controlar estados de los botones al iniciar el componente
            //ColorFondoId = Color.Transparent;
            IsEnebledGuardar = false;
            IsEnebledCrear = true;
            IsEnebledModificar = true;
            IsEnebledBorrar = true;
            IsEnebledCancelar = false;
            isvisiblelistalibro = false;
            isvisiblelistasocio = false;

            _ = Listar_Libro();
            _ = MostrarLibros();
            _ = Listar_Socio();
            _ = MostrarSocio();

            // Cargar datos del id seleccionado
            txtidprestamo = objprestamos.ID_prestamo;
            txtidlibro = objprestamos.Libroid.ID_Libro;
            txtidsocio = objprestamos.Socioid.ID_socio;
            App.Current.MainPage.DisplayAlert("Advertencia", objprestamos.Libroid.ID_Libro, "Aceptar");
            App.Current.MainPage.DisplayAlert("Advertencia", objprestamos.Socioid.ID_socio, "Aceptar");
            App.Current.MainPage.DisplayAlert("Advertencia", objprestamos.ID_Libro.ID_Libro, "Aceptar");
            App.Current.MainPage.DisplayAlert("Advertencia", objprestamos.ID_Libro.ID_Libro, "Aceptar");

            txtfechadevolucion = objprestamos.Fechadevolucion.ToString();
            txtfechaprestamo= objprestamos.Fechaprestamo.ToString();
           
            if (objprestamos.Estatus == "Inactivo")
                ChkEstadoValidar = true;
            else
                ChkEstadoValidar = false;

           
            CrearCommand = new Command(async () => await Crear());
            ModificarCommand = new Command(async () => await Modificar());
            CancelarCommand = new Command(async () => await Cancelar());
            BorrarCommand = new Command(async () => await Borrar());
            GuardarCambiosCommand = new Command(async () => await GuardarCambios());
          
            VolverCommand = new Command(async () => await Volver());

        }

        public AgregarPrestamosVM(INavigation navigation,
        MPrestamo esp = null, MSocios Socio= null , MLibros Libro=null)
        {
           
            txtidprestamo = esp.ID_prestamo;
           txtfechaprestamo= esp.Fechaprestamo.ToString();
            txtfechadevolucion= esp.Fechadevolucion.ToString() ;
            txtestatus = esp.Estatus;
            txtidlibro = esp.ToString();
            txtidsocio= esp.ToString(); 


           
        }
        public Command AgregarPrestamocommand { get; }
        #endregion
       

    }
}
