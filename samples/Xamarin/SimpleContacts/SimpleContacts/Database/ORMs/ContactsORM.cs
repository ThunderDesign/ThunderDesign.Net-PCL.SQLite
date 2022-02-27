using SQLite;
using System;
using ThunderDesign.Net.SQLite.ORMs;
using ThunderDesign.Net.Threading.Extentions;

namespace SimpleContacts.Database.ORMs
{
    [Table("Contacts")]
    public class ContactsORM : BaseSQLiteORM_AutoIncrement<ushort>
    {
        #region properties
        [Column("first_name")]
        public string FirstName
        {
            get { return this.GetProperty(ref _FirstName, _Locker); }
            set { this.SetProperty(ref _FirstName, value, _Locker, true); }
        }

        [Column("last_name")]
        public string LastName
        {
            get { return this.GetProperty(ref _LastName, _Locker); }
            set { this.SetProperty(ref _LastName, value, _Locker, true); }
        }
        #endregion

        #region variables
        protected string _FirstName = String.Empty;
        protected string _LastName = String.Empty;
        #endregion
    }
}
