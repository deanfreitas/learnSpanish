using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

        public T GetOneObjectById<T>(int id) where T : new()
        {
            var connection = _sqliteWrapper.OpenDatabase();
            var result = connection.GetAsync<T>(id);

            if (result.IsCanceled || result.IsFaulted)
            {
                throw new Exception($"Error select {typeof(T).Name} by id ==> {result.Exception}");
            }

            return result.Result;
        }

        public T GetObjectByUniqueName<T>(string name) where T : new()
        {
            var connection = _sqliteWrapper.OpenDatabase();
            var result = connection.QueryAsync<T>($"SELECT * FROM {typeof(T).Name} WHERE Symbol = ?", name);

            if (result.IsCanceled || result.IsFaulted)
            {
                throw new Exception($"Error select {typeof(T).Name} by name ==> {result.Exception}");
            }

            return result.Result[0];
        }

        public List<T> GetListObject<T>() where T : new()
        {
            var connection = _sqliteWrapper.OpenDatabase();
            var result = connection.Table<T>().ToListAsync();

            if (result.IsCanceled || result.IsFaulted)
            {
                throw new Exception($"Error select {typeof(T).Name} ==> {result.Exception}");
            }

            return result.Result;
        }

        public void Insert<T>(object o) where T : new()
        {
            var connection = _sqliteWrapper.OpenDatabase();
            var result = connection.InsertAsync(o);

            if (result.IsCanceled || result.IsFaulted)
            {
                throw new Exception($"Error insert in {typeof(T).Name} ==> {result.Exception}");
            }
        }

        public void Delete<T>(int id) where T : new()
        {
            var connection = _sqliteWrapper.OpenDatabase();
            var result = connection.DeleteAsync<T>(id);

            if (result.IsCanceled || result.IsFaulted)
            {
                throw new Exception($"Error delete in {typeof(T).Name} ==> {result.Exception}");
            }

            if (result.Result != 1)
            {
                throw new Exception($"Error delete in {typeof(T).Name} ==> rows affected: {result.Result}");
            }
        }
    }
}