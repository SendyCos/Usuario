using System;
using Acr.UserDialogs;
using Syncfusion.SfRotator.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Usuario
{
    public partial class RotatorPromos : ContentPage
    {
        private ObservableCollection<SfRotatorItem> _imagenes;

        public RotatorPromos()
        {
            InitializeComponent();
            _imagenes = new ObservableCollection<SfRotatorItem>();

            ObtenerFRottor();
            //carrusel.ItemsSource = _imagenes;
            //carrusel.ItemTemplate = new DataTemplate();

            _imagenes.Add(new SfRotatorItem()
            {
                ItemContent = new Image()
                {
                    Source = "http://i.imgur.com/fRrAzCL.jpg"
                }
            });
            try
            {
                var cargando = UserDialogs.Instance.Loading("Cargando...");

                // carousel.BindingContext = new ClassCarouselViewModel();
                rotator.ItemsSource = _imagenes;
                cargando.Hide();
                rotator.SelectedIndex = 0;
            }

            catch (System.Net.WebException ex)
            {
                DisplayAlert("Nse", "Se travo", "Aceptar", "Cancelar");
            }
            catch (System.Threading.Tasks.TaskCanceledException)
            {
                DisplayAlert("jaja", "otra vez se travo", "Aceptar", "Cancelar");
            }

            rotator.ItemsSource = _imagenes;
            rotator.ItemTemplate = new DataTemplate();
        }

        //Metodo para obtener las fotos en el carrousel//

        //public async void Task<IEnumerable<Galeriaa>> ObtenerFGaleria()
        public async void ObtenerFRottor()
        {
            var colecc = await App.AzureService.ObtenerPromociones();

            foreach (var a in colecc)
            {

                _imagenes.Add(new SfRotatorItem()
                {
                    ItemContent = new Image()
                    {
                        Source = a.urlImagen
                    }
                });
                rotator.ItemsSource = _imagenes;
                //return _imagenes;
                //carrusel.ItemsSource.Add(a.urlimagen);








            }
        }
    }
}
