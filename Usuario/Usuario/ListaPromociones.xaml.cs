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
    public partial class ListaPromociones : ContentPage
    {
        
        public ListaPromociones()
        {
            InitializeComponent();

        }
        protected async override void OnAppearing()
        {
            try
            {
                base.OnAppearing();

                var cargando = UserDialogs.Instance.Loading("Cargando...");
                lsvPromociones.ItemsSource = await App.AzureService.ObtenerPromociones();
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

        private void lsvPromociones_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {

                Promociones promo = e.SelectedItem as Promociones;
                PaginaPromociones pagina = new PaginaPromociones();
                pagina.ID = promo.Id;
                Navigation.PushAsync(pagina);

            }
        }

       
    
}
}
