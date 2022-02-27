using SimpleContacts.Database.ORMs;
using SimpleContacts.Interfaces;
using SQLite;
using System;
using System.Linq;

namespace SimpleContacts.Models
{
    [Table("Contacts")]
    public class ContactsModel : ContactsORM, IBaseModel<ushort>
    {
        #region properties
        [Ignore]
        public string FullName
        {
            get { return GetFullName(); }
        }
        #endregion

        #region methods
        protected virtual string GetFullName()
        {
            return $"{LastName}, {FirstName}";
        }

        public override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);

            string[] array = { nameof(this.FirstName), nameof(this.LastName) };
            if (array.Contains(propertyName, StringComparer.OrdinalIgnoreCase))
            {
                base.OnPropertyChanged(nameof(this.FullName));
            }
        }
        #endregion
    }
}
