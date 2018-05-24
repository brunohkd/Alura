using System;

using Android.App;
using Android.Content.PM;
using Android.OS;
using App1.Droid;
using Android.Provider;
using Android.Content;
using Xamarin.Forms;
using App1.Media;
using Plugin.Media;
using Java.Lang.Reflect;
using Android.Support.V4.Content;
using Android.Support.Compat;

[assembly: Xamarin.Forms.Dependency(typeof(MainActivity))]
namespace App1.Droid
{
    [Activity(Label = "App1", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity , ICamera
    {
        static Java.IO.File arquivoImagem;
        public void TirarFoto()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);

            arquivoImagem = PegarArquivoImagem();

            //intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(arquivoImagem));
            intent.PutExtra(MediaStore.ExtraOutput, arquivoImagem);
            intent.AddFlags(ActivityFlags.GrantReadUriPermission);
            intent.AddFlags(ActivityFlags.GrantWriteUriPermission);



            //var activity = Forms.Context as Activity;
            var activity = Forms.Context as Activity;
            activity.StartActivityForResult(intent, 0);
            
        }

        private static Java.IO.File PegarArquivoImagem()
        {
            Java.IO.File arquivoImagem;

            Java.IO.File diretorio = new Java.IO.File(Android.OS.Environment.GetExternalStoragePublicDirectory(
                Android.OS.Environment.DirectoryPictures), "Imagens");

            if (!diretorio.Exists())
            {
                diretorio.Mkdirs();
            }

            arquivoImagem = new Java.IO.File(diretorio, "MinhaFoto.jpg");
            return arquivoImagem;
        }

        protected async override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            await CrossMedia.Current.Initialize();

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if(resultCode == Result.Ok) {

                byte[] bytes;

                using (var stream = new Java.IO.FileInputStream(arquivoImagem)) {
                    bytes = new byte[arquivoImagem.Length()];
                    stream.Read(bytes);
                }
                MessagingCenter.Send<byte[]>(bytes, "FotoTirada");
            }
        }
    }
}

