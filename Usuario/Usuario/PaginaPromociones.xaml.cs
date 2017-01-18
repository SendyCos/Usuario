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
    public partial class PaginaPromociones : ContentPage
    {
        public string ID = "";

        public PaginaPromociones()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {

            try
            {
                base.OnAppearing();

                var cargando = UserDialogs.Instance.Loading("Cargando...");
                Promociones histo = await App.AzureService.ObtenerPromocion(ID);
                lblnombre.Text = histo.Nombre;
                lbldescrrip.Text = histo.Descripcion;
                lbldia.Text = histo.Dia;
                lblImagen.Source = histo.urlImagen;
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
    }
}
