using ThunderDesign.Net.Threading.Interfaces;

namespace ThunderDesign.Net.SQLite.Interfaces
{
    public interface ISQLiteORM : IBindableDataObject
    {
    }

    public interface ISQLiteORM<Key> : IBindableDataObject<Key>, ISQLiteORM
    {
    }
}
