using learnSpanish.Sqlite.Interface;
using Xamarin.Forms;

namespace learnSpanish.Sqlite
{
    public class SqliteWrapper
    {
        private string _dbPath;

        public SqliteWrapper()
        {
            _dbPath = DependencyService.Get<ISqlite>().GetPathFile();
        }
    }
}