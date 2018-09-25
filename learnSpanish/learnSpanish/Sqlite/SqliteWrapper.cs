using learnSpanish.Sqlite.Interface;
using SQLite;
using Xamarin.Forms;

namespace learnSpanish.Sqlite
{
    public class SqliteWrapper
    {
        private readonly string _dbPath;
        private SQLiteAsyncConnection _connection;

        public SqliteWrapper()
        {
            _dbPath = DependencyService.Get<ISqlite>().GetPathFile();
        }

        public SQLiteAsyncConnection OpenDatabase()
        {
            if (_connection != null)
            {
                return _connection;
            }

            _connection = new SQLiteAsyncConnection(_dbPath);
            return _connection;
        }
    }
}