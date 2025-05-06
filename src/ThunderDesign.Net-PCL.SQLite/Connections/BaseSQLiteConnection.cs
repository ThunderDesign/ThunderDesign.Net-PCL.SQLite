using SQLite;
using System;
using System.IO;
using ThunderDesign.Net.SQLite.Interfaces;
using ThunderDesign.Net.Threading.Objects;
using ISQLiteConnection = ThunderDesign.Net.SQLite.Interfaces.ISQLiteConnection;

namespace ThunderDesign.Net.SQLite.Connections
{
    public abstract class BaseSQLiteConnection : ThreadObject, ISQLiteConnection
    {
        #region constructors
        public BaseSQLiteConnection(string databaseFilename, string databasePath = null, SQLiteOpenFlags? flags = null)
        {
            const string defaultDatabaseExtention = "db3";
            string defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            SQLiteOpenFlags defaultFlags = SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.SharedCache | SQLiteOpenFlags.FullMutex;

            databaseFilename = Path.GetFileName(databaseFilename);

            if (string.IsNullOrEmpty(databaseFilename))
                throw new ArgumentNullException($"Database Filename is null or Empty.", nameof(databaseFilename));

            DatabaseFilename = Path.HasExtension(databaseFilename) ? databaseFilename : Path.ChangeExtension(databaseFilename, defaultDatabaseExtention); ;
            DatabasePath = !String.IsNullOrEmpty(databasePath) ? databasePath : defaultPath;
            Flags = flags ?? defaultFlags;
        }
        #endregion

        #region properties
        public SQLiteAsyncConnection Database
        {
            get { return GetDatabase(); }
        }

        public string DatabaseFilename
        {
            get;
            private set;
        }

        public string DatabasePath
        {
            get;
            private set;
        }

        public SQLiteOpenFlags Flags
        {
            get;
            private set;
        }

        public string DatabaseFullname
        {
            get { return Path.Combine(DatabasePath, DatabaseFilename); }
        }
        #endregion

        #region methods
        private SQLiteAsyncConnection GetDatabase()
        {
            if (_Database == null)
            {
                lock (_Locker)
                {
                    if (_Database == null)
                    {
                        _Database = new SQLiteAsyncConnection(DatabaseFullname, Flags);
                    }
                }
            }
            return _Database;
        }
        #endregion

        #region variables
        private SQLiteAsyncConnection _Database = null;
        #endregion
    }
}
