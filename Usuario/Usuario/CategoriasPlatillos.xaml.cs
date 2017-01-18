using Usuario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Xamarin.Forms;

namespace Usuario
{
    public partial class CategoriasPlatillos : ContentPage
    {
        private TapGestureRecognizer _tap;
        //----------------private AzureServiceManager _azureServiceManager;

        public CategoriasPlatillos()
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
            base.OnAppearing();
            var carg = UserDialogs.Instance.Loading("Cargando...");
            lstvCategorias.ItemsSource = await App.AzureService.ObtenerCategorias();
            carg.Hide();
            //grdMain.Opacity = 0;
            //await grdMain.FadeTo(1, 500);
        }

      
    }
}
