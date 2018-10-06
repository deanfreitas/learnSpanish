using System;
using System.Linq;
using System.Threading.Tasks;

namespace learnSpanish.Sqlite
{
    public class SqliteTable
    {
        private readonly SqliteWrapper _sqliteWrapper;

        public SqliteTable()
        {
            _sqliteWrapper = new SqliteWrapper();
        }

        private async Task<bool> CheckIfExistTable<T>() where T : new()
        {
            var connection = _sqliteWrapper.OpenDatabase();
            try
            {
                var result = await connection.Table<T>().CountAsync();
                return result.Equals(0);
            }
            catch (Exception e)
            {
                Logs.Logs.Error($"Error get count table {typeof(T).Name}: {e.Message}");
                return false;
            }
        }

        public async void CreateTable<T>() where T : new()
        {
            var connection = _sqliteWrapper.OpenDatabase();

            if (await CheckIfExistTable<T>())
            {
                Logs.Logs.Info($"This table {typeof(T).Name} was created");
                return;
            }

            connection.CreateTableAsync<T>().Wait();
        }
    }
}