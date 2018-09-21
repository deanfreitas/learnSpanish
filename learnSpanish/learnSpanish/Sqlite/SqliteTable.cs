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

        private bool CheckIfExistTable<T>() where T : new()
        {
            var connection = _sqliteWrapper.OpenDatabase();
            
            var result = connection.Table<T>().CountAsync().Result;
            return result > 0;
        }

        public void CreateTable<T>() where T : new()
        {
            var connection = _sqliteWrapper.OpenDatabase();
            
            if (CheckIfExistTable<T>())
            {
                return;
            }

            var createTableResult = connection.CreateTableAsync<T>().Result;
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