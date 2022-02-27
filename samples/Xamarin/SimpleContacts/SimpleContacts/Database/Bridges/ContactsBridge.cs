using SimpleContacts.Database.Tables;
using SimpleContacts.Models;
using ThunderDesign.Net.SQLite.Bridges;

namespace SimpleContacts.Database.Bridges
{
    public class ContactsBridge : BaseBridge<ushort, ContactsModel>
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
                lock (_Locker)
                {
                    return _Instance ??= new ContactsBridge();
                }
            }
        }
        #endregion

        #region variables
        protected readonly static object _Locker = new object();
        private static ContactsBridge _Instance = null;
        #endregion
    }
}
