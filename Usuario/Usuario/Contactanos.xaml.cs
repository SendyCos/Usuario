using Plugin.Messaging;
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
    public partial class Contactanos : ContentPage
    {
        //MAPAS
        TapGestureRecognizer gestortap1 = new TapGestureRecognizer();
        private InfoPerol histo;
        protected async override void OnAppearing()
        {
            try
            {

                base.OnAppearing();

                var car = UserDialogs.Instance.Loading("Cargando...");
                histo = await App.AzureService.ObtenerInfoPerol();
                lblDireccion.Text = histo.Direccion;
                lblHorario.Text = histo.Horario;
                car.Hide();
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
        public void cargarMapa(string rutaArchivo)
        {
            imgFoto.Source = ImageSource.FromFile(rutaArchivo);
        }



        public Contactanos()
        {

            InitializeComponent();
            btnCorreo.Clicked += BtnCorreo_Clicked;
            btnLlamada.Clicked += BtnLlamada_Clicked;
            btnSitioWeb.Clicked += BtnSitioWeb_Clicked;
            btnSms.Clicked += BtnSms_Clicked;
            //imgCarrito.Clicked += ImgCarrito_Clicked;


            //TAPMAPAS
            gestortap1.Tapped += Gestortap1_Tapped;
            gestortap1.NumberOfTapsRequired = 1;
            imgFoto.GestureRecognizers.Add(gestortap1);
        }

        async private void ImgCarrito_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CarritoCompras());
        }

        private async void BtnSms_Clicked(object sender, EventArgs e)
        {
            //MessagingCenter.Send<Contactanos>(this, "SMS");
            if (CrossMessaging.Current.SmsMessenger.CanSendSms)
            {
                var msj = histo.Telefono;
                CrossMessaging.Current.SmsMessenger.SendSms(msj);

            }
        }

        private void BtnSitioWeb_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send<Contactanos>(this, "Sitio Web");
        }

        private void BtnLlamada_Clicked(object sender, EventArgs e)
        {
            //  MessagingCenter.Send<Contactanos>(this, "LLAMADAS");

            if (CrossMessaging.Current.PhoneDialer.CanMakePhoneCall)
            {
                var msj = histo.Telefono;
                CrossMessaging.Current.PhoneDialer.MakePhoneCall(msj);

            }
        }

        private void BtnCorreo_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send<Contactanos>(this, "CORREO");
        }

        private void Gestortap1_Tapped(object sender, EventArgs e)
        {
            MessagingCenter.Send<Contactanos>(this, "Abrir Mapas");
        }
    }
}
