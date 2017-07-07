using Piolhos.App.Core.Interfaces;
using SQLite.Net.Interop;
using SQLite.Net.Platform.XamarinIOS;
using System;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(Piolhos.App.iOS.DataAccess.DataBaseConfig))]
namespace Piolhos.App.iOS.DataAccess
{
    public class DataBaseConfig : IDataBaseConfig
    {
        private string _directory;
        public string Directory
        {
            get
            {
                if (string.IsNullOrEmpty(_directory))
                {
                    var directory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    _directory = Path.Combine(directory, "..", "Library");
                }
                return _directory;
            }
        }

        private ISQLitePlatform _platform;
        public ISQLitePlatform Platform
        {
            get
            {
                if (_platform == null)
                    _platform = new SQLitePlatformIOS();

                return _platform;
            }
        }
    }
}
