using System.Collections.Generic;
using System.Threading.Tasks;
using ThunderDesign.Net.SQLite.Interfaces;
using ThunderDesign.Net.Threading.Objects;

namespace ThunderDesign.Net.SQLite.Tables
{
    public class BaseSQLiteTable<ORM> : ThreadObject, ISQLiteTable<ORM> where ORM : ISQLiteORM, new()
    {
        #region constructors
        public BaseSQLiteTable(ISQLiteConnection databaseConnection) : base()
        {
            DatabaseConnection = databaseConnection;
            databaseConnection.Database.CreateTableAsync<ORM>().GetAwaiter().GetResult();
        }
        #endregion

        #region properties
        public ISQLiteConnection DatabaseConnection
        {
            get;
            private set;
        }
        #endregion

        #region methods
        protected virtual async Task<ORM> GetRecordAsync(string id)
        {
            return await DatabaseConnection.Database.Table<ORM>().Where(i => i.Id.ToString() == id).FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public virtual async Task<ORM> GetRecordAsync(sbyte id)
        {
            return await GetRecordAsync(id.ToString()).ConfigureAwait(false);
        }

        public virtual async Task<ORM> GetRecordAsync(short id)
        {
            return await GetRecordAsync(id.ToString()).ConfigureAwait(false);
        }

        public virtual async Task<ORM> GetRecordAsync(int id)
        {
            return await GetRecordAsync(id.ToString()).ConfigureAwait(false);
        }

        public virtual async Task<ORM> GetRecordAsync(long id)
        {
            return await GetRecordAsync(id.ToString()).ConfigureAwait(false);
        }

        public virtual async Task<ORM> GetRecordAsync(byte id)
        {
            return await GetRecordAsync(id.ToString()).ConfigureAwait(false);
        }

        public virtual async Task<ORM> GetRecordAsync(ushort id)
        {
            return await GetRecordAsync(id.ToString()).ConfigureAwait(false);
        }

        public virtual async Task<ORM> GetRecordAsync(uint id)
        {
            return await GetRecordAsync(id.ToString()).ConfigureAwait(false);
        }

        public virtual async Task<ORM> GetRecordAsync(ulong id)
        {
            return await GetRecordAsync(id.ToString()).ConfigureAwait(false);
        }

        public virtual async Task<List<ORM>> GetRecordsAsync()
        {
            return await DatabaseConnection.Database.Table<ORM>().ToListAsync().ConfigureAwait(false);
        }

        public virtual async Task<int> UpdateRecordAsync(ORM item)
        {
            return await DatabaseConnection.Database.UpdateAsync(item).ConfigureAwait(false);
        }

        public virtual async Task<int> InsertRecordAsync(ORM item)
        {
            return await DatabaseConnection.Database.InsertAsync(item).ConfigureAwait(false);
        }

        public virtual async Task<int> DeleteRecordAsync(ORM item)
        {
            return await DatabaseConnection.Database.DeleteAsync(item).ConfigureAwait(false);
        }

        public virtual async Task ResetTableAsync()
        {
            await DatabaseConnection.Database.DropTableAsync<ORM>().ConfigureAwait(false);
            await DatabaseConnection.Database.CreateTableAsync<ORM>().ConfigureAwait(false);
        }
        #endregion
    }
}
