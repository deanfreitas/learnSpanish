using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using learnSpanish.Model;
using learnSpanish.Sqlite.Interface;
using SQLite;
using Xamarin.Forms;

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
                throw new Exception($"Error select {typeof(T).Name} by id ==> not found id: {id}");
            }

            return result;
        }

        public async Task<T> GetObjectByUniqueName<T>(string name) where T : new()
        {
            var connection = _sqliteWrapper.OpenDatabase();
            var result = await connection.QueryAsync<T>($"SELECT * FROM {typeof(T).Name} WHERE login_user=?", name);

            if (result == null || !result.Any())
            {
                throw new Exception($"Error select {typeof(T).Name} by name ==> This name not exist in database");
            }

            return result[0];
        }

        public async Task<List<T>> GetListObject<T>() where T : new()
        {
            var connection = _sqliteWrapper.OpenDatabase();
            var result = await connection.Table<T>().ToListAsync();

            if (result == null)
            {
                throw new Exception($"Error select {typeof(T).Name} ==> Not found values int this table");
            }

            return result;
        }

        public async void Insert<T>(object o) where T : new()
        {
            var connection = _sqliteWrapper.OpenDatabase();
            await connection.InsertAsync(o);
        }

        public async void Delete<T>(int id) where T : new()
        {
            var connection = _sqliteWrapper.OpenDatabase();
            var result = await connection.DeleteAsync<T>(id);

            if (result != 1)
            {
                throw new Exception($"Error delete in {typeof(T).Name} ==> rows affected: {result}");
            }
        }
    }
}