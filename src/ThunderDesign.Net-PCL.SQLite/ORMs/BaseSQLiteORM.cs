using SQLite;
using System;
using System.Linq;
using ThunderDesign.Net.SQLite.Interfaces;
using ThunderDesign.Net.Threading.DataObjects;

namespace ThunderDesign.Net.SQLite.ORMs
{
    public abstract class BaseSQLiteORM<Key> : BindableDataObject<Key>, ISQLiteORM<Key>
    {
        #region constructors
        public BaseSQLiteORM() : base()
        {
            string[] allowedKeys =
            {
                typeof(sbyte).ToString(), //-128 to 127
                typeof(short).ToString(), //-32,768 to 32,767
                typeof(int).ToString(), //-2,147,483,648 to 2,147,483,647
                typeof(long).ToString(), //-9,223,372,036,854,775,808 to 9,223,372,036,854,775,807
                typeof(byte).ToString(), //0 to 255
                typeof(ushort).ToString(), //0 to 65,535
                typeof(uint).ToString(), //0 to 4,294,967,295
                typeof(ulong).ToString() //0 to 18,446,744,073,709,551,615
            };

            if (!allowedKeys.Contains(typeof(Key).ToString()))
                throw new ArgumentException($"Key '{typeof(Key)}' is invalid.", typeof(Key).ToString());
        }
        #endregion

        #region properties
        [PrimaryKey]
        [Column("id")]
        public new Key Id
        {
            get { return base.Id; }
            set { base.Id = value; }
        }
        #endregion
    }
}
