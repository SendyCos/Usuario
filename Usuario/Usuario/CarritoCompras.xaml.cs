using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuario.Models;
using Xamarin.Forms;

namespace Usuario
{
    public partial class CarritoCompras : ContentPage
    {
        
        //public CarritoCompras(List<Platillos> platillos)
        //{
        //    InitializeComponent();
        //    lstCarrito.SwipeEnded += LstCarrito_SwipeEnded;
            
        //    if (platillos != null)
        //    {
        //        lstCarrito.ItemsSource = platillos;
        //        var total = platillos.Sum(p => p.Precio);
        //        lblTotal.Text = total.ToString("C");
        //    }
        //}

        private void LstCarrito_SwipeEnded(object sender, Syncfusion.ListView.XForms.SwipeEndedEventArgs e)
        {
            if (e.SwipeOffset >= 360)
            {
                lstCarrito.ResetSwipe();
            }
        }

        
    }
}

