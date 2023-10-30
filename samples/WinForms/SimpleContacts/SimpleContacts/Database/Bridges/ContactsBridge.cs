using SimpleContacts.Database.Tables;
using SimpleContacts.Databases.ORMs;
using ThunderDesign.Net.SQLite.Bridges;

namespace SimpleContacts.Database.Bridges
{
    public class ContactsBridge : BaseBridge<ushort, ContactsORM>
    {
        #region constructors
        public ContactsBridge() : base(ContactsTable.Instance)
        {
        }
        #endregion

        #region properties
        public static ContactsBridge Instance
        {
            get
            {
                lock (_InstanceLocker)
                {
                    return _Instance ??= new ContactsBridge();
                }
            }
        }
        #endregion

        #region variables
        private readonly static object _InstanceLocker = new object();
        private static ContactsBridge? _Instance = null;
        #endregion
    }
}
