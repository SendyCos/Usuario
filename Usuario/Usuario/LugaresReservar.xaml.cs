using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuario.Models;
using Xamarin.Forms;

namespace Usuario
{
    public partial class LugaresReservar : ContentPage
    {
        private List<Platillos> _platillosCarrito;
        public LugaresReservar()
        {
            InitializeComponent();
            btnReservar.Clicked += BtnReservar_Clicked;
            imgCarrito.Clicked += ImgCarrito_Clicked;
        }

        private async void ImgCarrito_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new CarritoCompras(_platillosCarrito));
        }

        async private void BtnReservar_Clicked(object sender, EventArgs e)
        {
            int mesa = int.Parse(txtMesas.Items[txtMesas.SelectedIndex]);
            int personas = (int.Parse(txtMesas.Items[txtPersonas.SelectedIndex]));
            DateTime fecha = txtFecha.Date;
            ActivityIndicator.IsRunning = true;
            await App.AzureService.AgregarReservaciones(mesa, personas, fecha);
            ActivityIndicator.IsRunning = false;
            await Navigation.PushAsync(new Login());
        }
    
}
}
