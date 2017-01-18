using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Xamarin.Forms;

namespace Usuario
{
    public partial class Inicio : ContentPage
    {
        public Inicio()
        {
            InitializeComponent();

            //ROTATOR
            //rotator.BindingContext = new ClassRotatorViewModel();

            TapGestureRecognizer clickConocenos = new TapGestureRecognizer();
            clickConocenos.Tapped += ClickConocenos_Tapped;
            btnconocenos.GestureRecognizers.Add(clickConocenos);

            TapGestureRecognizer clickMenu = new TapGestureRecognizer();
            clickMenu.Tapped += ClickMenu_Tapped;
            btnMenuu.GestureRecognizers.Add(clickMenu);

            TapGestureRecognizer clickGaleria = new TapGestureRecognizer();
            clickGaleria.Tapped += ClickGaleria_Tapped;
            btngaleria.GestureRecognizers.Add(clickGaleria);


            TapGestureRecognizer clickContactanos = new TapGestureRecognizer();
            clickContactanos.Tapped += ClickContactanos_Tapped;
            btncontaacto.GestureRecognizers.Add(clickContactanos);


            TapGestureRecognizer clickPromo = new TapGestureRecognizer();
            clickPromo.Tapped += ClickPromo_Tapped;
            btnpromo.GestureRecognizers.Add(clickPromo);

            TapGestureRecognizer clickReserv = new TapGestureRecognizer();
            clickReserv.Tapped += ClickReserv_Tapped;
            btnreservac.GestureRecognizers.Add(clickReserv);


            //imgCarrito.Clicked += ImgCarrito_Clicked;
        }

        async private void ClickReserv_Tapped(object sender, EventArgs e)
        {
            UserDialogs.Instance.Alert("Estamos trabajando en ello...", "Aviso", "Aceptar");
        }

        async private void ClickPromo_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListaPromociones());
        }

        async private void ClickContactanos_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Contactanos());
        }

        async private void ClickGaleria_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Galeria());
        }
        private string _categoria;
        async private void ClickMenu_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CategoriasPlatillos2());
        }

        async private void ClickConocenos_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Conocenos());
        }

        //async private void ImgCarrito_Clicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new CarritoCompras());
        //}







    }
}
