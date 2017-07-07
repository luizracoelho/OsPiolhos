using Piolhos.App.Core.Interfaces;
using SQLite.Net.Interop;
using SQLite.Net.Platform.XamarinAndroid;
using System;

[assembly: Xamarin.Forms.Dependency(typeof(Piolhos.App.Droid.DataAccess.DataBaseConfig))]
namespace Piolhos.App.Droid.DataAccess
{
    public class DataBaseConfig : IDataBaseConfig
    {
        private string _directory;
        public string Directory
        {
            get
            {
                if (string.IsNullOrEmpty(_directory))
                    _directory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

                return _directory;
            }
        }

        private ISQLitePlatform _platform;
        public ISQLitePlatform Platform
        {
            get
            {
                if (_platform == null)
                    _platform = new SQLitePlatformAndroid();

                return _platform;
            }
        }
    }
}