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
    public partial class CategoriasPlatillos2 : ContentPage
    {
        private TapGestureRecognizer _tap;
        //----------------private AzureServiceManager _azureServiceManager;

        public CategoriasPlatillos2()
        {
            InitializeComponent();

            _tap = new TapGestureRecognizer();
            _tap.Tapped += TapOnTapped;
            //-------------_azureServiceManager = new AzureServiceManager();

            lstvCategorias.ItemTapped += lstvCategoriasOnItemTapped;
            //crcPaninis.GestureRecognizers.Add(_tap);
        }

        private async void lstvCategoriasOnItemTapped(object sender, ItemTappedEventArgs itemTappedEventArgs)
        {
            var categoriaSeleccionada = itemTappedEventArgs.Item as Categorias;
            if (categoriaSeleccionada != null)
            {
                await Navigation.PushAsync(new VariedadCategoria(categoriaSeleccionada.Nombre));
            }
        }

        private async void TapOnTapped(object sender, EventArgs eventArgs)
        {
            await Navigation.PushModalAsync(new VariedadCategoria("categoriaSeleccionada"));
        }

        protected override async void OnAppearing()
        {

            try
            {
                base.OnAppearing();
                var carg = UserDialogs.Instance.Loading("Cargando");
                lstvCategorias.ItemsSource = await App.AzureService.ObtenerCategorias();
                carg.Hide();
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
