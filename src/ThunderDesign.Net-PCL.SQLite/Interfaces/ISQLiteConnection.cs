using SQLite;

namespace ThunderDesign.Net.SQLite.Interfaces
{
    public interface ISQLiteConnection
    {
        #region properties
        SQLiteAsyncConnection Database { get; }

        //string DatabaseFilename { get; }

        //string DatabasePath { get; }

        //SQLiteOpenFlags Flags { get; }

        //string DatabaseFullname { get; }
        #endregion
    }
}
