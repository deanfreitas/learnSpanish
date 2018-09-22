using System;
using System.Threading.Tasks;
using learnSpanish.Model;
using SQLite;
using Xamarin.Forms.Internals;

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

            var createTableResult = await connection.CreateTableAsync<T>();
            if (createTableResult == CreateTableResult.Created)
            {
                Logs.Logs.Info($"Create table {typeof(T).Name}");
            }
            else
            {
                throw new Exception("Error create table");
            }
        }
    }
}