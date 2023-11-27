using SQLite;
using System.ComponentModel;
using System.Reflection;
using System.Threading.Tasks;
using ThunderDesign.Net.SQLite.Interfaces;
using ThunderDesign.Net.Threading.DataCollections;
using ThunderDesign.Net.ToolBox.Extentions;

namespace ThunderDesign.Net.SQLite.Bridges
{
    public class BaseBridge<TKey, TValue> : ObservableDataDictionary<TKey, TValue> where TValue : ISQLiteORM<TKey>, new()
    {
        #region constructors
        public BaseBridge(ISQLiteTable<TValue> bridgeTable) : base()
        {
            BridgeTable = bridgeTable;
            PropertyInfo propertyInfo = typeof(TValue).GetProperty(nameof(ISQLiteORM.Id));
            IsKeyAutoIncrement = (propertyInfo.GetCustomAttribute(typeof(AutoIncrementAttribute)) != null);
            LoadFromSQLite().ConfigureAwait(false).GetAwaiter().GetResult();
        }
        #endregion

        #region properties
        public bool IsKeyAutoIncrement { get; private set; }

        public ISQLiteTable<TValue> BridgeTable { get; private set; }
        #endregion

        #region methods
        public new void Add(TValue value)
        {
            _ReaderWriterLockSlim.EnterUpgradeableReadLock();
            try
            {
                if (!IsKeyAutoIncrement)
                    base.Add(value);

                BridgeTable.InsertRecordAsync(value).ConfigureAwait(false).GetAwaiter().GetResult();

                if (IsKeyAutoIncrement)
                {
                    base.Add(value);
                }

                value.PropertyChanged += OnChildPropertyChanged;
            }
            finally
            {
                _ReaderWriterLockSlim.ExitUpgradeableReadLock();
            }
        }

        public new void Clear()
        {
            _ReaderWriterLockSlim.EnterUpgradeableReadLock();
            try
            {
                Task task = BridgeTable.ResetTableAsync();
                foreach (var record in Values)
                {
                    record.PropertyChanged -= OnChildPropertyChanged;
                }
                base.Clear();
                task.ConfigureAwait(false).GetAwaiter().GetResult();
            }
            finally
            {
                _ReaderWriterLockSlim.ExitUpgradeableReadLock();
            }
        }

        public new bool Remove(TKey key)
        {
            bool result = false;

            _ReaderWriterLockSlim.EnterUpgradeableReadLock();
            try
            {
                if (this.ContainsKey(key))
                {
                    TValue value = this[key];
                    Task<int> task = BridgeTable.DeleteRecordAsync(value);
                    value.PropertyChanged -= OnChildPropertyChanged;
                    result = base.Remove(key);
                    task.ConfigureAwait(false).GetAwaiter().GetResult();
                }
            }
            finally
            {
                _ReaderWriterLockSlim.ExitUpgradeableReadLock();
            }
            return result;
        }

        private async Task LoadFromSQLite()
        {
            TValue baseRecordORM;

            var baseRecords = await BridgeTable.GetRecordsAsync().ConfigureAwait(false);
            if (baseRecords.Count > 0)
            {
                _ReaderWriterLockSlim.EnterWriteLock();
                try
                {
                    foreach (var baseRecord in baseRecords)
                    {
                        baseRecordORM = new TValue();
                        baseRecordORM.Mirror(baseRecord);
                        baseRecordORM.PropertyChanged += OnChildPropertyChanged;
                        base.Add(baseRecordORM.Id, baseRecordORM);
                    }
                }
                finally
                {
                    _ReaderWriterLockSlim.ExitWriteLock();
                }
            }
        }

        private void OnChildPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender is TValue value)
            {
                BridgeTable.UpdateRecordAsync(value).ConfigureAwait(false).GetAwaiter().GetResult();
            }
        }
        #endregion
    }
}
