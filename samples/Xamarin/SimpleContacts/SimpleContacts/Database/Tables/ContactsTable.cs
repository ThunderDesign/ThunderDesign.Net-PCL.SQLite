using SimpleContacts.Database.Connections;
using SimpleContacts.Models;
using ThunderDesign.Net.SQLite.Tables;

namespace SimpleContacts.Database.Tables
{
    public class ContactsTable : BaseSQLiteTable<ContactsModel>
    {
        #region constructors
        public ContactsTable() : base(SimpleContactsConnection.Instance)
        {
        }
        #endregion

        #region properties
        public static ContactsTable Instance
        {
            get
            {
                lock (_InstanceLocker)
                {
                    return _Instance ??= new ContactsTable();
                }
            }
        }
        #endregion

        #region variables
        private readonly static object _InstanceLocker = new object();
        private static ContactsTable _Instance = null;
        #endregion
    }
}
