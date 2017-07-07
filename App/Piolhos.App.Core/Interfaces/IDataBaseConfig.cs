using SQLite.Net.Interop;

namespace Piolhos.App.Core.Interfaces
{
    public interface IDataBaseConfig
    {
        string Directory { get; }
        ISQLitePlatform Platform { get; }
    }
}
