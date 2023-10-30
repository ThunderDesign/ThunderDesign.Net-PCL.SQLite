using ThunderDesign.Net.SQLite.Connections;

namespace SimpleContacts.Databases.Connections
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
                lock (_InstanceLocker)
                {
                    return _Instance ??= new SimpleContactsConnection();
                }
            }
        }
        #endregion

        #region variables
        private readonly static object _InstanceLocker = new object();
        private const string _DatabaseFilename = "Contacts.db3";
        private static SimpleContactsConnection? _Instance = null;
        #endregion
    }
}
