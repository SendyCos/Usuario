using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Usuario.Models;

using Xamarin.Forms;

namespace Usuario
{
    public partial class Conocenos : ContentPage
    {
        public Conocenos()
        {
            InitializeComponent();

            //imgCarrito.Clicked += ImgCarrito_Clicked;
        }

        protected async override void OnAppearing()
        {
            try
            {

                base.OnAppearing();
                var cargando = UserDialogs.Instance.Loading("Cargando...");
                InfoPerol histo = await App.AzureService.ObtenerInfoPerol();
                lblHistoria.Text = histo.Historia;
                cargando.Hide();
            }
            catch (System.Net.WebException ex)
            {
                UserDialogs.Instance.ShowError("Sin Acceso a Internet", 2000);
                //await DisplayAlert("Nse", "Se travo", "Aceptar", "Cancelar");
            }
            catch (System.Threading.Tasks.TaskCanceledException)
            {
                UserDialogs.Instance.ShowError("Sin Acceso a Internet", 2000);
                //await  DisplayAlert("jaja", "otra vez se travo", "Aceptar", "Cancelar");
            }

        }


        //async private void ImgCarrito_Clicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new CarritoCompras());

        //}

    }
}
