using ThunderDesign.Net.SQLite.Interfaces;

namespace SimpleContacts.Interfaces
{
    public interface IBaseModel : ISQLiteORM
    {
    }
    public interface IBaseModel<Key> : ISQLiteORM<Key>, IBaseModel
    {
    }
}
