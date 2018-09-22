using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using learnSpanish.Enums.Sql;
using learnSpanish.Exceptions;

namespace learnSpanish.Sqlite
{
    public class SqliteService
    {
        private readonly SqliteWrapper _sqliteWrapper;

        public SqliteService()
        {
            _sqliteWrapper = new SqliteWrapper();
        }

        public async Task<T> GetOneObjectById<T>(int id) where T : new()
        {
            var connection = _sqliteWrapper.OpenDatabase();
            var result = await connection.GetAsync<T>(id);

            if (result == null)
            {
                throw new SqliteServiceException(TableSql.Select, typeof(T).Name, $"not found id = {id}");
            }

            return result;
        }

        public async Task<T> GetObjectByUniqueValue<T>(Dictionary<string, string> values) where T : new()
        {
            var connection = _sqliteWrapper.OpenDatabase();
            var result = await connection.QueryAsync<T>(
                $"SELECT * FROM {typeof(T).Name} WHERE {values.Keys.FirstOrDefault()}=?",
                values.Values.FirstOrDefault());

            if (result == null || !result.Any())
            {
                throw new SqliteServiceException(TableSql.Select, typeof(T).Name,
                    $"This {values.Keys.FirstOrDefault()} not exist in database");
            }

            return result[0];
        }

        public async Task<List<T>> GetListObject<T>() where T : new()
        {
            var connection = _sqliteWrapper.OpenDatabase();
            var result = await connection.Table<T>().ToListAsync();

            if (result == null)
            {
                throw new SqliteServiceException(TableSql.Select, typeof(T).Name, "Not found values in this table");
            }

            return result;
        }

        public async Task<List<T>> GetListObjectByQuery<T>(string query) where T : new()
        {
            if (query.IndexOf("Select", StringComparison.OrdinalIgnoreCase) > 0)
            {
                throw new SqliteServiceException(TableSql.Select, typeof(T).Name, "This method need to select query");
            }

            var connection = _sqliteWrapper.OpenDatabase();
            var result = await connection.QueryAsync<T>(query);

            if (result == null || !result.Any())
            {
                throw new SqliteServiceException(TableSql.Select, typeof(T).Name, "Not found values in this table");
            }

            return result;
        }

        public async void Insert<T>(object o) where T : new()
        {
            var connection = _sqliteWrapper.OpenDatabase();
            var result = await connection.InsertAsync(o);

            if (!result.Equals(1))
            {
                throw new SqliteServiceException(TableSql.Insert, typeof(T).Name, $"rows add: {result}");
            }
        }

        public async void Update<T>(object o) where T : new()
        {
            var connection = _sqliteWrapper.OpenDatabase();
            var result = await connection.UpdateAsync(o);

            if (!result.Equals(1))
            {
                throw new SqliteServiceException(TableSql.Update, typeof(T).Name, $"rows updated: {result}");
            }
        }

        public async void Delete<T>(int id) where T : new()
        {
            var connection = _sqliteWrapper.OpenDatabase();
            var result = await connection.DeleteAsync<T>(id);

            if (!result.Equals(1))
            {
                throw new SqliteServiceException(TableSql.Delete, typeof(T).Name, $"rows deleted: {result}");
            }
        }
    }
}