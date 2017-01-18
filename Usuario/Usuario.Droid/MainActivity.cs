using System;
using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using Android.Content;

namespace Usuario.Droid
{
    [Activity(Label = "Usuario", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();
            UserDialogs.Init(this);
            

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());


            //MAPAS
            MessagingCenter.Subscribe<Contactanos>(this, "Abrir Mapas", (remitente) =>
            {
                var ubicacionURI = Android.Net.Uri.Parse("geo:0,0?q=el+perolito+muzquiz+coahuila");
                var intent = new Intent(Intent.ActionView, ubicacionURI);
                StartActivity(intent);
            });

            ////LLAMADAS
            //MessagingCenter.Subscribe<Contactanos>(this, "LLAMADAS", (remitente) =>
            //{

            //    var uri = Android.Net.Uri.Parse("");
            //    var intent = new Intent(Intent.ActionDial, uri);
            //    StartActivity(intent);

            //});


            //PAGINA WEB
            MessagingCenter.Subscribe<Contactanos>(this, "Sitio Web", (remitente) =>
            {
                var uri = Android.Net.Uri.Parse("https://www.facebook.com/ElPerolitoMuzquiz/?fref=ts");
                var intent = new Intent(Intent.ActionView, uri);
                StartActivity(intent);
            });

            ////SMS
            //MessagingCenter.Subscribe<Contactanos>(this, "SMS", (remitente) =>
            //{
            //    var smsUri = Android.Net.Uri.Parse("smsto:8641007711");
            //    var smsIntent = new Intent(Intent.ActionSendto, smsUri);
            //    smsIntent.PutExtra("sms_body", "Escribenos tu Mensaje");
            //    StartActivity(smsIntent);

            //});

            //CORREO
            MessagingCenter.Subscribe<Contactanos>(this, "CORREO", (remitente) =>
            {
                var email = new Intent(Android.Content.Intent.ActionSend);

                email.PutExtra(Android.Content.Intent.ExtraCc,
                new string[] { "perolitomqz@hotmail.com" });

                email.PutExtra(Android.Content.Intent.ExtraSubject, "Hola Perol");

                email.SetType("message / rfc822");

                StartActivity(email);

            });
        }
    }
}

