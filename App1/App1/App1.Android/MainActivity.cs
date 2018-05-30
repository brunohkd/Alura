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
using Android;
using Android.Support.V4.App;
using Android.Util;
using Android.Support.Design.Widget;
using static Android.Resource;
using Android.Runtime;
using Android.Widget;
using Android.Graphics;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(MainActivity))]
namespace App1.Droid
{
    [Activity(Label = "App1", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity , ICamera
    {
        static Java.IO.File arquivoImagem;
        public void TirarFoto()
        {

            if(ContextCompat.CheckSelfPermission(Forms.Context, Manifest.Permission.Camera) == Permission.Granted) { 

                Intent intent = new Intent(MediaStore.ActionImageCapture);

                arquivoImagem = PegarArquivoImagem();

                //intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(arquivoImagem));
                intent.PutExtra(MediaStore.ExtraOutput, arquivoImagem);

                //var activity = Forms.Context as Activity;
                var activity = Forms.Context as Activity;
                activity.StartActivityForResult(intent, 0);
            } else
            {
                ActivityCompat.RequestPermissions(Forms.Context as Activity, new string[] {
                    Manifest.Permission.Camera, Manifest.Permission.WriteExternalStorage,
                    Manifest.Permission.ReadExternalStorage }, 100);
            }

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

                try
                {
                    using (var stream = new Java.IO.FileInputStream(arquivoImagem)) {
                        bytes = new byte[arquivoImagem.Length()];
                        stream.Read(bytes);
                    }
                } catch
                {
                    Bitmap bitmap = (Bitmap)data.Extras.Get("data");
                    bytes = new byte[bitmap.Width * bitmap.Height * 4];
                    using (var stream = new MemoryStream()) { 
                        bitmap.Compress(Bitmap.CompressFormat.Png, 80, stream);
                        stream.Flush();
                    }
                }

                MessagingCenter.Send<byte[]>(bytes, "FotoTirada");
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            if(requestCode == 100)
            {
                Log.Info("TAG", "RequestCode igual a 100.");
                if ((grantResults.Length == 1) && (grantResults[0] == Permission.Granted))
                {
                    Log.Info("TAG", "Recebido a permissão de Camera");
                    TirarFoto();
                    
                } else
                {
                    Log.Info("TAG", "Não recebido a permissão de Camera");
                    Toast.MakeText(this, "Não foi possível abrir a camera.", Android.Widget.ToastLength.Short);
                }
            }
            else
            {
                Log.Info("TAG", "RequestCode é diferente.");
                base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            }
        }
    }
}

