using Acr.UserDialogs;
using Syncfusion.SfCarousel.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace Usuario
{
    public partial class Galeria : ContentPage
    {
        private ObservableCollection<SfCarouselItem> _imagenes;

        public Galeria()
        {

            try
            {
                InitializeComponent();
                _imagenes = new ObservableCollection<SfCarouselItem>();

                ObtenerFGaleria();

                //carrusel.ItemsSource = _imagenes;
                //carrusel.ItemTemplate = new DataTemplate();

                _imagenes.Add(new SfCarouselItem()
                {
                    ItemContent = new Image()
                    {
                        Source = "http://i.imgur.com/NrhOBnn.jpg"
                    }
                });
                var cargando = UserDialogs.Instance.Loading("Cargando...");

                // carousel.BindingContext = new ClassCarouselViewModel();
                carrusel.ItemsSource = _imagenes;
                cargando.Hide();
                carrusel.SelectedIndex = 0;
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

            carrusel.ItemsSource = _imagenes;
            carrusel.ItemTemplate = new DataTemplate();
        }

        //Metodo para obtener las fotos en el carrousel//

        //public async void Task<IEnumerable<Galeriaa>> ObtenerFGaleria()
        public async void ObtenerFGaleria()
        {
            try
            {
                var cargando = UserDialogs.Instance.Loading("Cargando...");

                var colecc = await App.AzureService.ObtenerFotosdeGaleria();
               
                foreach (var a in colecc)
                {

                    _imagenes.Add(new SfCarouselItem()
                    {
                        ItemContent = new Image()
                        {
                            Source = a.urlimagen
                        }
                    });
                    carrusel.ItemsSource = _imagenes;
                    //return _imagenes;
                    //carrusel.ItemsSource.Add(a.urlimagen);
                    cargando.Hide();
                }

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
