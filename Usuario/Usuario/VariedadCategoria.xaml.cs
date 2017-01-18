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
    public partial class VariedadCategoria : ContentPage
    {
        //-------------private AzureServiceManager _azureServiceManager;
        private string _categoriaSeleccionada;

        public VariedadCategoria(string categoria)
        {
            InitializeComponent();

            //-------------------- _azureServiceManager = new AzureServiceManager();
            _categoriaSeleccionada = categoria;


        }
       

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var car = UserDialogs.Instance.Loading("Cargando..");
            var platillos = await App.AzureService.ObtenerListaPlatillosCategorias(_categoriaSeleccionada);
            
            lstPlatilloss.ItemsSource = platillos;
            car.Hide();
        }

        private void LstPlatilloss_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {

                Platillos platillo = e.SelectedItem as Platillos;
                DescripcionPlatillo pagina = new DescripcionPlatillo();
                pagina.ID = platillo.Id;
                Navigation.PushAsync(pagina);

            }
        }
    }


}
