using SQLite;
using ThunderDesign.Net.SQLite.ORMs;
using ThunderDesign.Net.Threading.Extentions;

namespace SimpleContacts.Databases.ORMs
{
    [Table("Contacts")]
    public class ContactsORM : BaseSQLiteORM_AutoIncrement<ushort>
    {
        #region properties
        [Column("first_name")]
        public string FirstName
        {
            get { return this.GetProperty(ref _FirstName, _Locker); }
            set
            {
                if (this.SetProperty(ref _FirstName, value, _Locker, true))
                    this.OnPropertyChanged(nameof(FullName));
            }
        }

        [Column("last_name")]
        public string LastName
        {
            get { return this.GetProperty(ref _LastName, _Locker); }
            set
            {
                if (this.SetProperty(ref _LastName, value, _Locker, true))
                    this.OnPropertyChanged(nameof(FullName));
            }
        }

        [Ignore]
        public string FullName
        {
            get { return GetFullName(); }
        }
        #endregion

        #region methods
        private string GetFullName()
        {
            return $"{LastName}, {FirstName} = {Id}";
        }
        #endregion

        #region variables
        protected string _FirstName = String.Empty;
        protected string _LastName = String.Empty;
        #endregion

    }
}
