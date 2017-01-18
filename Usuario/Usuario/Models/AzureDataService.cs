using System;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Usuario.Models;
using System.Linq;
using Xamarin.Forms;
namespace Usuario.Models
{
    public class AzureDataService
    {

        public MobileServiceClient MobileService { get; set; }
        IMobileServiceSyncTable<Platillos> tablaPlatillos;
        IMobileServiceSyncTable<Categorias> tablaCategorias;
        IMobileServiceSyncTable<InfoPerol> tablaInfoPerol;
        IMobileServiceSyncTable<Usuarios> tablaUsuario;
        IMobileServiceSyncTable<Galeria> tablaGaleria;
        IMobileServiceSyncTable<Reservaciones> tablaReservacions;
        IMobileServiceSyncTable<Promociones> tablaPromocines;


        bool isInitialized;

        public async Task Initialize()
        {
            if (isInitialized)
                return;
            MobileService = new MobileServiceClient("http://perolito-mqz-app.azurewebsites.net");
            const string path = "syncstore-perolito-mqz.db";

            var store = new MobileServiceSQLiteStore(path);

            store.DefineTable<Platillos>();
            store.DefineTable<Categorias>();
            store.DefineTable<InfoPerol>();
            store.DefineTable<Usuarios>();
            store.DefineTable<Galeria>();
            store.DefineTable<Reservaciones>();
            store.DefineTable<Promociones>();

            await MobileService.SyncContext.InitializeAsync(store, new MobileServiceSyncHandler());

            tablaPlatillos = MobileService.GetSyncTable<Platillos>();
            tablaCategorias = MobileService.GetSyncTable<Categorias>();
            tablaInfoPerol = MobileService.GetSyncTable<InfoPerol>();
            tablaUsuario = MobileService.GetSyncTable<Usuarios>();
            tablaGaleria = MobileService.GetSyncTable<Galeria>();
            tablaReservacions = MobileService.GetSyncTable<Reservaciones>();
            tablaPromocines = MobileService.GetSyncTable<Promociones>();
            isInitialized = true;

        }


        //////////////////////////////////////////Promociones///////////////////////////////////
        public async Task<IEnumerable<Promociones>> ObtenerPromociones()
        {
            await Initialize();
            await SyncPromociones();
            return await tablaPromocines.OrderBy(a => a.Nombre).ToEnumerableAsync();
        }

        public async Task<Promociones> ObtenerPromocion(string id)
        {
            await Initialize();
            await SyncPromociones();
            return (await tablaPromocines.Where(a => a.Id == id).Take(1).ToEnumerableAsync()).FirstOrDefault();
        }

        public async Task<Promociones> AgregarPromocion(string nombre, string descripcion, string dia, string imagen)
        {
            await Initialize();
            var item = new Promociones
            {
                Nombre = nombre,
                Descripcion = descripcion,
                Dia = dia,
                urlImagen = imagen
            };

            await tablaPromocines.InsertAsync(item);
            await SyncPromociones();
            return item;
        }


        public async Task<Promociones> ModificarPromocion(string id, string nombre, string descripcion, string dia, string imagen)
        {
            await Initialize();
            var item = await ObtenerPromocion(id);
            item.Nombre = nombre;
            item.Descripcion = descripcion;
            item.Dia = dia;
            item.urlImagen = imagen;

            await tablaPromocines.UpdateAsync(item);
            await SyncPromociones();
            return item;
        }

        public async Task EliminarPromocion(string id)
        {
            await Initialize();
            var item = await ObtenerPromocion(id);
            await tablaPromocines.DeleteAsync(item);
            await SyncPromociones();
        }

        private async Task SyncPromociones()
        {
            await tablaPromocines.PullAsync("Promociones", tablaPromocines.CreateQuery());
            await MobileService.SyncContext.PushAsync();
        }

        public async Task<Promociones> GuardarUrlPromociones(string imag)
        {
            await Initialize();

            var item = new Promociones()
            {
                urlImagen = imag

            };
            await tablaPromocines.InsertAsync(item);
            await SyncPromociones();
            return item;
        }



        ///////////////////////////////////////Galeria//////////////////



        public async Task<Galeria> GuardarUrlGaleria(string imag)
        {
            await Initialize();

            var item = new Galeria()
            {
                urlimagen = imag

            };
            await tablaGaleria.InsertAsync(item);
            await SyncGaleria();
            return item;
        }

        private async Task SyncGaleria()
        {
            await tablaGaleria.PullAsync("Galeria", tablaGaleria.CreateQuery());
            await MobileService.SyncContext.PushAsync();
        }


        public async Task<IEnumerable<Galeria>> ObtenerFotosdeGaleria()
        {
            await Initialize();
            await SyncGaleria();
            return await tablaGaleria.OrderBy(a => a.urlimagen).ToEnumerableAsync();
        }




        //////////////////////////////////Tabla Usuarios//////////////////////////////
        public async Task<IEnumerable<Usuarios>> ObtenerUsuarios()
        {
            await Initialize();
            await SyncUsuarios();
            return await tablaUsuario.OrderBy(a => a.Nombre).ToEnumerableAsync();
        }

        public async Task<Usuarios> ObtenerUsuario(string id)
        {
            await Initialize();
            await SyncUsuarios();
            return (await tablaUsuario.Where(a => a.Id == id).Take(1).ToEnumerableAsync()).FirstOrDefault();
        }



        public async Task<Usuarios> AgregarUsuario(string nombre, string apellido, string correo, string contraseña, string telefono, string direccion)
        {
            await Initialize();

            var item = new Usuarios()
            {
                Nombre = nombre,
                Apellido = apellido,
                Correo = correo,
                Contraseña = contraseña,
                Telefono = telefono,
                Direccion = direccion


            };
            await tablaUsuario.InsertAsync(item);
            await SyncUsuarios();
            return item;
        }

        public async Task<Usuarios> ModificarUsuario(string id, string nombre, string apellido, string correo, string contraseña, string telefono, string direccion)
        {
            await Initialize();
            var item = await ObtenerUsuario(id);
            item.Nombre = nombre;
            item.Apellido = apellido;
            item.Correo = correo;
            item.Contraseña = contraseña;
            item.Telefono = telefono;
            item.Direccion = direccion;

            await tablaUsuario.UpdateAsync(item);
            await SyncUsuarios();
            return item;
        }

        public async Task EliminarUsuario(string id)
        {
            await Initialize();
            var item = await ObtenerUsuario(id);
            await tablaUsuario.DeleteAsync(item);
            await SyncUsuarios();
        }

        private async Task SyncUsuarios()
        {
            await tablaUsuario.PullAsync("Usuarios", tablaUsuario.CreateQuery());
            await MobileService.SyncContext.PushAsync();
        }




        //////////////////////////////////Tabla Platillos//////////////////////////////
        public async Task<IEnumerable<Platillos>> ObtenerPlatillos()
        {
            await Initialize();
            await SyncPlatillos();
            return await tablaPlatillos.OrderBy(a => a.Nombre).ToEnumerableAsync();
        }

        public async Task<Platillos> ObtenerPlatillo(string id)
        {
            await Initialize();
            await SyncPlatillos();
            return (await tablaPlatillos.Where(a => a.Id == id).Take(1).ToEnumerableAsync()).FirstOrDefault();
        }

        public async Task<Platillos> Obtenerpla()
        {
            await Initialize();
            await SyncPlatillos();
            var info2 = await (from i in tablaPlatillos
                               select i).ToListAsync();
            return info2.FirstOrDefault();
        }
        //public async Task<Platillos> AgregarPlatillos(string nombre, string descripcion, decimal precio)
        //{
        //    await Initialize();

        //    var item = new Platillos
        //    {
        //        Nombre = nombre,
        //        Descripciom = descripcion,
        //        Precio = precio
        //    };
        //    await tablaPlatillos.InsertAsync(item);
        //    await SyncPlatillos();
        //    return item;
        //}

        //public async Task<Platillos> ModificarPlatillo(string id, string nombre, string descripcion, decimal precio)
        //{
        //    await Initialize();
        //    var item = await ObtenerPlatillo(id);
        //    item.Nombre = nombre;
        //    item.Descripciom = descripcion;
        //    item.Precio = precio;

        //    await tablaPlatillos.UpdateAsync(item);
        //    await SyncPlatillos();
        //    return item;
        //}

        //public async Task EliminarPlatillo(string id)
        //{
        //    await Initialize();
        //    var item = await ObtenerPlatillo(id);
        //    await tablaPlatillos.DeleteAsync(item);
        //    await SyncPlatillos();
        //}

        private async Task SyncPlatillos()
        {
            await tablaPlatillos.PullAsync("Platillos", tablaPlatillos.CreateQuery());
            await MobileService.SyncContext.PushAsync();
        }


        ////////////////////////////////Tabla Categoria/////////////////////////////////////
        public async Task<IEnumerable<Categorias>> ObtenerCategorias()
        {
            await Initialize();
            await SyncCategorias();
            return await tablaCategorias.OrderBy(a => a.Nombre).ToEnumerableAsync();
        }

        public async Task<Categorias> ObtenerCategoria(string id)
        {
            await Initialize();
            await SyncCategorias();
            return (await tablaCategorias.Where(a => a.Id == id).Take(1).ToEnumerableAsync()).FirstOrDefault();
        }

        public async Task<IEnumerable<Platillos>> ObtenerListaPlatillosCategorias(string categoria)
        {
            await Initialize();
            await SyncPlatillos();
            
            //return (await tablaPlatillos.Where(a => a.Id == NombreCat).ToListAsync());
            return await tablaPlatillos.Where(a => a.Categorias == categoria).ToListAsync();


            //var variable = await tablaPlatillos.ToListAsync();
            //return variable;

        }


        //public async Task<Categorias> AgregarCategorias(string nombre)
        //{
        //    await Initialize();

        //    var item = new Categorias()
        //    {
        //        Nombre = nombre,

        //    };
        //    await tablaCategorias.InsertAsync(item);
        //    await SyncCategorias();
        //    return item;
        //}

        //public async Task<Categorias> ModificarCategoria(string id, string nombre)
        //{
        //    await Initialize();
        //    var item = await ObtenerCategoria(id);
        //    item.Nombre = nombre;

        //    await tablaCategorias.UpdateAsync(item);
        //    await SyncCategorias();
        //    return item;
        //}

        //public async Task EliminarCategoria(string id)
        //{
        //    await Initialize();
        //    var item = await ObtenerCategoria(id);
        //    await tablaCategorias.DeleteAsync(item);
        //    await SyncCategorias();
        //}

        private async Task SyncCategorias()
        {
            await tablaCategorias.PullAsync("Categorias", tablaCategorias.CreateQuery());
            await MobileService.SyncContext.PushAsync();
        }

        /////////////////////////////Informacionn del perol/////////////////////////(////////////////////////




        public async Task<InfoPerol> ObtenerInfoPerol()
        {
            await Initialize();
            await SyncInformacionPerol();
            var info = await (from i in tablaInfoPerol
                              select i).ToListAsync();
            return info.FirstOrDefault();
        }

        private async Task SyncInformacionPerol()
        {
            await tablaInfoPerol.PullAsync("InfoPerol", tablaInfoPerol.CreateQuery());
            await MobileService.SyncContext.PushAsync();
        }








        //////////////////////////////////Tabla RESERVACIONES//////////////////////////////
        public async Task<IEnumerable<Reservaciones>> ObtenerReservaciones()
        {
            await Initialize();
            await SyncReservaciones();
            return await tablaReservacions.OrderBy(a => a.Fecha).ToEnumerableAsync();
        }

        public async Task<Reservaciones> ObtenerReservacion(string id)
        {
            await Initialize();
            await SyncReservaciones();
            return (await tablaReservacions.Where(a => a.Id == id).Take(1).ToEnumerableAsync()).FirstOrDefault();
        }


        public async Task<Reservaciones> AgregarReservaciones(int mesa, int personas, DateTime fehca)
        {
            await Initialize();

            var item = new Reservaciones()
            {
                Mesa = mesa,

                Personas = personas,
                Fecha = fehca,



            };
            await tablaReservacions.InsertAsync(item);
            await SyncReservaciones();
            return item;
        }

        public async Task<Reservaciones> ModificarReservvaciones(string id, int mesa, int personas, DateTime fecha)
        {
            await Initialize();
            var item = await ObtenerReservacion(id);
            item.Mesa = mesa;
            item.Personas = personas;
            item.Fecha = fecha;

            await tablaReservacions.UpdateAsync(item);
            await SyncReservaciones();
            return item;
        }

        public async Task EliminarReservaciones(string id)
        {
            await Initialize();
            var item = await ObtenerReservacion(id);
            await tablaReservacions.DeleteAsync(item);
            await SyncReservaciones();
        }

        private async Task SyncReservaciones()
        {
            await tablaReservacions.PullAsync("Reservaciones", tablaReservacions.CreateQuery());
            await MobileService.SyncContext.PushAsync();
        }
    }
}

