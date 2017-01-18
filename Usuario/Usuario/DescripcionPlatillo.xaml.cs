using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuario.Models;
using Xamarin.Forms;

namespace Usuario
{
    public partial class DescripcionPlatillo : ContentPage
    {
        public string ID = "";

        public DescripcionPlatillo()
        {
            InitializeComponent();

        }

        protected async override void OnAppearing()
        {

            try
            {
                base.OnAppearing();

                var cargando = UserDialogs.Instance.Loading("Cargando...");
                Platillos histo = await App.AzureService.ObtenerPlatillo(ID);
                lblnombre.Text = histo.Nombre;
                lbldescrrip.Text = histo.Descripciom;
                lbImagen.Source = histo.urlImagen;
                
                lblPrecio.Text = histo.Precio.ToString("$0.00");
                cargando.Hide();
            }
           
                catch (System.Net.WebException ex)
            {
                UserDialogs.Instance.ShowError("ERROR", 2000);
                //await DisplayAlert("Nse", "Se travo", "Aceptar", "Cancelar");
            }
            catch (System.Threading.Tasks.TaskCanceledException)
            {
                UserDialogs.Instance.ShowError("ERROR", 2000);
                //await  DisplayAlert("jaja", "otra vez se travo", "Aceptar", "Cancelar");
            }

        
           

        }


        private async void ImgCarrito2_OnClicked(object sender, EventArgs e)
        {
            
        }
    }
}
