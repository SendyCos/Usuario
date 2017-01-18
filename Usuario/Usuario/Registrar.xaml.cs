using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Usuario
{
    public partial class Registrar : ContentPage
    {

        public string ID = " ";

        public Registrar()
        {
            InitializeComponent();
            btnCrearRegistrar.Clicked += BtnCrearRegistrar_Clicked;
        }


        async private void BtnCrearRegistrar_Clicked(object sender, EventArgs e)
        {
            string nombre = lblNombre.Text;
            string apellido = lblApellido.Text;
            string correo = lblCorreo.Text;
            string telefono = lblTelefono.Text;
            string contraseña = lblContraseña.Text;
            string direcci = lblDirecc.Text;
            if (ID == String.Empty)
            {
                await App.AzureService.AgregarUsuario(nombre, apellido, correo, contraseña, telefono, direcci);
                await DisplayAlert("Aviso", "Se agrego Correctamente", "Aceptar", "Cancelar");
            }
        }
        //async void btnGuardar_Click(object sender, EventArgs a)
        //{
        //    string nombre = lblNombre.Text;
        //    string apellido = lblApellido.Text;
        //    string correo = lblCorreo.Text;
        //    string telefono = lblTelefono.Text;
        //    string contraseña = lblContraseña.Text;
        //    string direcci = lblDirecc.Text;

        //    if (ID == String.Empty)
        //        await App.AzureService.AgregarPlatillos(nombre, descripcion, precio, categoria);
        //    else
        //        await App.AzureService.ModificarPlatillo(ID, nombre, descripcion, precio, categoria);
        //    await Navigation.PopAsync();

        //}
    }
}
