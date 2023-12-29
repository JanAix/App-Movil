using Biblioteca.Datos;
using Biblioteca.Modelo;
using Biblioteca.Vistas.Tablas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Biblioteca.VistaModelo
{
    public class AgregarLibroVM : BaseVistaModelo
    {

        #region atributo
        public string id_libro;
        public string nombrelibro;
        public string estatus;
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
        public object listalibro;
        public bool isvisible = false;
        #endregion

        #region propiedades

        #region Campos Modelo
        public bool isenebledcancelar = true;

        public string txtidlibro
        {
            get { return id_libro; }
            set { SetValue(ref id_libro, value); }
        }
        public string txtlibro
        {
            get { return nombrelibro; }
            set { SetValue(ref nombrelibro, value); }
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
        public object Listalibro
        {
            get { return listalibro; }
            set { SetValue(ref listalibro, value); }
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
        

        public ObservableCollection<MLibros> librocollection = new ObservableCollection<MLibros>();

        private async Task TestListViewBindingAsync()
        {

            var lista = new List<MLibros>();
            {
                var funcion = new DTLibros();
                lista = await funcion.Mostrarlibros();

            }
            foreach (var item in lista)
            {
                librocollection.Add(item);
            }

        }


        public async Task MostrarLibros()
        {
            IsRefrescar = true;
            await Task.Delay(100);
            Listalibro = await db.Mostrarlibros();
            IsRefrescar = false;
        }
        public async Task Buscar_En_DBLibros()
        {
            List<MLibros> Listprov = await db.Mostrarlibros();
            foreach (var encontrado in Listprov)
            {
                librocollection.Add(encontrado);
            }
        }

        public async Task Crear()
        {
            List<MLibros> registros = await db.Mostrarlibros();
            int cant_registros = registros.Count();
            int IdGenerado;

            if (cant_registros == 0)
                IdGenerado = 1;
            else
                IdGenerado = cant_registros + 1;

            txtidlibro = string.Format("L{0:000}", IdGenerado);
            txtlibro = "";
            txtestatus = "";



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
                if (string.IsNullOrEmpty(txtlibro))
                {
                    await App.Current.MainPage.DisplayAlert("Advertencia", "Debe de indicar el libro.", "Aceptar");
                    return;
                }
                if (ChkEstadoValidar == true)
                    estatus = "Prestado";
                else
                    estatus = "Disponible";
                #endregion

                //Instanciamos el modelo para obtener los datos introducidos por el usuario
                var obj = new MLibros
                {
                    ID_Libro = id_libro,
                    Libro = nombrelibro,
                    Estatus = estatus,

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

                        await db.InsertarLibro(obj);

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

                    bool respuesta = await db.ModificarDatosLibros(obj);

                    CorrerBarra = false;
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
            var obj = new MLibros
            {
                ID_Libro = id_libro,
                Libro = nombrelibro,
                Estatus = estatus,

            };


            await db.ModificarDatosLibros(obj);




        }

        public async Task Borrar()
        {
            try
            {
                List<MSocios> ListEspObtenida = await dbsocio.MostrarSocio();
                var objlibro = new MLibros()
                {
                    ID_Libro = id_libro
                };

                if (string.IsNullOrEmpty(txtidlibro))
                {
                    await App.Current.MainPage.DisplayAlert("Información", "Debe seleccionar un libro.", "Aceptar");
                }
                else
                {
                    string respuesta = await App.Current.MainPage.DisplayActionSheet("¿Seguro que desea borrar este libro?", "Cancelar", null, "Si", "No");
                    if (respuesta == "Si")
                    {
                        bool relacion = ListEspObtenida.Select(r => r.Libro.ID_Libro == objlibro.ID_Libro).FirstOrDefault();
                        if (relacion == true)
                        {
                            await App.Current.MainPage.DisplayAlert("Advertecia", "No se puede borrar una especialidad que esté relacionada a un doctor.", "Aceptar");
                        }
                        else
                        {
                            CorrerBarra = true;
                            IsVisible = true;
                            await Task.Delay(1000);

                            await db.BorrarLibros(objlibro);

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
                txtidlibro = "";
                txtlibro = "";
                txtestatus = "";
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
      

        public async Task NavegarAgregar()
        {
            await Navigation.PushAsync(new AgregarL());
            

        }


        public async Task Ir_CrearLibros()
        {
           
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

        public AgregarLibroVM(INavigation navegar)
        {
            Navigation = navegar;


            NavegarAgregarCommand = new Command(async () => await NavegarAgregar());
            //Controlar estados al iniciar el componente
            ColorFondoId = System.Drawing.Color.Transparent;

            IsEnebledGuardar = false;
            IsEnebledCancelar = false;
            IsEnebledCrear = true;
            IsEnebledModificar = false;
            IsEnebledBorrar = false;

            RefrescarCommand = new Command(async () => await MostrarLibros());
            CrearCommand = new Command(async () => await Crear());
            GuardarCambiosCommand = new Command(async () => await GuardarCambios());
            ModificarCommand = new Command(async () => await Modificar());

            CancelarCommand = new Command(async () => Cancelar());
            BorrarCommand = new Command(async () => await Borrar());
            VolverCommand = new Command(async () => await Volver());


            
            _ = MostrarLibros();
            _ = TestListViewBindingAsync();
            _ = Crear();
            
        }

        
        public AgregarLibroVM(MLibros obj)
        {
            //Cargar datos del id seleccionado
            txtidlibro = obj.ID_Libro;
            txtlibro = obj.Libro;
            txtestatus = obj.Estatus;

            if (obj.Estatus == "Prestado")
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
           // ModificarCommand = new Command(async () => await Modificar());
            CancelarCommand = new Command(async () => Cancelar());
            BorrarCommand = new Command(async () => await Borrar());
            VolverCommand = new Command(async () => await Volver());
            //PkEstado = DatosEstado().OrderBy(e => e.Texto).ToList();
            _ = MostrarLibros();
        }

        public AgregarLibroVM(INavigation navigation,
        MLibros esp = null)
        {

            txtidlibro = esp.ID_Libro;
            txtlibro = esp.Libro;
            txtestatus = esp.Estatus;
        }



        public Command NavegarAgregarCommand { get; }




        #endregion

    }
}



