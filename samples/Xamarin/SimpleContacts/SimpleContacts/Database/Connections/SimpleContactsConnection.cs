using System;
using System.IO;
using ThunderDesign.Net.SQLite.Connections;
using Xamarin.Forms;

namespace SimpleContacts.Database.Connections
{
    public class SimpleContactsConnection : BaseSQLiteConnection
    {
        #region constructors
        public SimpleContactsConnection() : base(_DatabaseFilename, GetDatabasePath())
        {
        }
        #endregion

        #region properties
        private static string GetDatabasePath()
        {
            string databasePath = "";
            if (Device.RuntimePlatform == Device.iOS)
            {
                // we need to put in /Library/ on iOS5.1+ to meet Apple's iCloud terms
                // (they don't want non-user-generated data in Documents)
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
                databasePath = Path.Combine(documentsPath, "..", "Library"); // Library folder instead
            }
            else if (Device.RuntimePlatform == Device.Android)
            {
                // Just use whatever directory SpecialPolder.Personal returns
                databasePath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            }
            return databasePath;
        }

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
        private static SimpleContactsConnection _Instance = null;
        #endregion
    }
}
