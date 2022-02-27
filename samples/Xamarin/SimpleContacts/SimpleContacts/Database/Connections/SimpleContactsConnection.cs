using ThunderDesign.Net.SQLite.Connections;

namespace SimpleContacts.Database.Connections
{
    public class SimpleContactsConnection : BaseSQLiteConnection
    {
        #region constructors
        public SimpleContactsConnection() : base(_DatabaseFilename)
        {
        }
        #endregion

        #region properties
        public static SimpleContactsConnection Instance
        {
            get
            {
                lock (_Locker)
                {
                    return _Instance ??= new SimpleContactsConnection();
                }
            }
        }
        #endregion

        #region variables
        private const string _DatabaseFilename = "Contacts.db3";
        private static SimpleContactsConnection _Instance = null;
        #endregion
    }
}
