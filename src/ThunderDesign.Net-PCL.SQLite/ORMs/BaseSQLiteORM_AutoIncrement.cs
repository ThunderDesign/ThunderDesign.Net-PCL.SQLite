using SQLite;

namespace ThunderDesign.Net.SQLite.ORMs
{
    public abstract class BaseSQLiteORM_AutoIncrement<Key> : BaseSQLiteORM<Key>
    {
        #region constructors
        public BaseSQLiteORM_AutoIncrement() : base()
        {
        }
        #endregion

        #region properties
        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public new Key Id
        {
            get { return base.Id; }
            set { base.Id = value; }
        }
        #endregion
    }
}
