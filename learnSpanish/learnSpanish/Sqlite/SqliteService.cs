using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using learnSpanish.Enums.Sql;
using learnSpanish.Exceptions;
using SQLiteNetExtensionsAsync.Extensions;

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
                throw new SqliteServiceException(TableSql.Select, typeof(T).Name, $"Not found id = {id}");
            }

            return result;
        }

        public async Task<T> GetObjectByUniqueValue<T>(Expression<Func<T, bool>> predicate) where T : new()
        {
            var connection = _sqliteWrapper.OpenDatabase();
            var result = await connection.FindAsync(predicate);

            if (result == null)
            {
                throw new SqliteServiceException(TableSql.Select, typeof(T).Name, "Not found value in this table");
            }

            return result;
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

        public async Task Insert<T>(object o) where T : new()
        {
            var connection = _sqliteWrapper.OpenDatabase();
            var result = await connection.InsertAsync(o);

            if (!result.Equals(1))
            {
                throw new SqliteServiceException(TableSql.Insert, typeof(T).Name, $"Rows add: {result}");
            }
        }

        public async Task InsertWithChildren(object o)
        {
            var connection = _sqliteWrapper.OpenDatabase();
            await connection.InsertWithChildrenAsync(o, recursive: true);
        }

        public async Task Update<T>(object o) where T : new()
        {
            var connection = _sqliteWrapper.OpenDatabase();
            var result = await connection.UpdateAsync(o);

            if (!result.Equals(1))
            {
                throw new SqliteServiceException(TableSql.Update, typeof(T).Name, $"Rows updated: {result}");
            }
        }

        public async Task Delete<T>(object o) where T : new()
        {
            var connection = _sqliteWrapper.OpenDatabase();
            var result = await connection.DeleteAsync(o);

            if (!result.Equals(1))
            {
                throw new SqliteServiceException(TableSql.Delete, typeof(T).Name, $"Rows deleted: {result}");
            }

        }
    }
}