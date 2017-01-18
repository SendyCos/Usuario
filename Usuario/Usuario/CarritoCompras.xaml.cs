using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayPal.Forms;
using PayPal.Forms.Abstractions;
using PayPal.Forms.Abstractions.Enum;
using Usuario.Models;
using Xamarin.Forms;

namespace Usuario
{
    public partial class CarritoCompras : ContentPage
    {

        public CarritoCompras(List<Platillos> platillos)
        {
            InitializeComponent();
            lstCarrito.SwipeEnded += LstCarrito_SwipeEnded;

            if (platillos != null)
            {
                lstCarrito.ItemsSource = platillos;
                var total = platillos.Sum(p => p.Precio);
                lblTotal.Text = total.ToString("C");
            }

            btnCheckout.Clicked += BtnCheckoutOnClicked;
        }

        private async void BtnCheckoutOnClicked(object sender, EventArgs eventArgs)
        {
            var result = await CrossPayPalManager.Current.Buy(new PayPalItem("Hamburguesa clásica", 105M, "MXN"), 0M);
            //new ShippingAddress("Abraham Chacón Landois", "Lomas Rosita", "sin nombre B-3", "Nueva Rosita", "Coahuila", "26880", "52"));
            if (result.Status == PayPalStatus.Cancelled)
            {

            }
        }

        private void LstCarrito_SwipeEnded(object sender, Syncfusion.ListView.XForms.SwipeEndedEventArgs e)
        {
            if (e.SwipeOffset >= 360)
            {
                lstCarrito.ResetSwipe();
            }
        }

        
    }
}

