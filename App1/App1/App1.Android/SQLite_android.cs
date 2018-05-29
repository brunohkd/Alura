using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App1.Data;
using App1.Droid;
using SQLite;

[assembly: Xamarin.Forms.Dependency(typeof(SQLite_android))]
namespace App1.Droid
{
    class SQLite_android : ISQLite
    {
        private const string NOME_ARQUIVO_DB = "Agendamento.db3";

        public SQLiteConnection PegarConexao()
        {

            //var caminhodb = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.Path, NOME_ARQUIVO_DB);

            //var path = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), NOME_ARQUIVO_DB);
            var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            path = Path.Combine(path, NOME_ARQUIVO_DB);


            return new SQLite.SQLiteConnection(path);
        }
    }
}