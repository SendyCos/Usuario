using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Usuario
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            btnCrearCuenta.Clicked += BtnCrearCuenta_Clicked;
            btnIniciarSesion.Clicked += BtnIniciarSesion_Clicked;
            //lblRecuperarContraseña.Clicked += LblRecuperarContraseña_Clicked;
            //imgCarrito.Clicked += ImgCarrito_Clicked;

        }

        //async private void ImgCarrito_Clicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new CarritoCompras());
        //}

        //async private void LblRecuperarContraseña_Clicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new RecuperarContraseña());
        //}

        async private void BtnIniciarSesion_Clicked(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(UsuarioEntry.Text))
            //{
            //    mensajeLabel.Text = "Debes Ingresar un Usuario";
            //    UsuarioEntry.Focus();
            //    return;
            //}
            //if (string.IsNullOrEmpty(claveEntry.Text))
            //{
            //    mensajeLabel.Text = "Debes ingresar una clave";
            //    claveEntry.Focus();
            //    return;
            //}

        }

        async private void BtnCrearCuenta_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registrar());
        }
    }
}

