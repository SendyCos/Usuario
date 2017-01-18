using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Usuario
{
    public partial class Carrusel : CarouselPage
    {
        public Carrusel()
        {
            InitializeComponent();
            btnComenzamos.Clicked += BtnComenzamos_Clicked;
        }

        private void BtnComenzamos_Clicked(object sender, EventArgs e)
        {
            //fgfcuaderno
            App.Current.MainPage = new Principio();

        }
    }
}
