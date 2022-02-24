using System.Collections.Generic;
using System.Threading.Tasks;

namespace ThunderDesign.Net.SQLite.Interfaces
{
    public interface ISQLiteTable
    {
    }

    public interface ISQLiteTable<ORM> where ORM : ISQLiteORM
    {
        Task<ORM> GetRecordAsync(sbyte id);

        Task<ORM> GetRecordAsync(short id);

        Task<ORM> GetRecordAsync(int id);

        Task<ORM> GetRecordAsync(long id);

        Task<ORM> GetRecordAsync(byte id);

        Task<ORM> GetRecordAsync(ushort id);

        Task<ORM> GetRecordAsync(uint id);

        Task<ORM> GetRecordAsync(ulong id);

        Task<List<ORM>> GetRecordsAsync();

        Task<int> UpdateRecordAsync(ORM item);

        Task<int> InsertRecordAsync(ORM item);

        Task<int> DeleteRecordAsync(ORM item);

        Task ResetTableAsync();
    }
}
