using System;
using System.IO;
using learnSpanish.Constants;
using learnSpanish.Droid.Files;
using learnSpanish.Sqlite.Interface;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileAndroid))]

namespace learnSpanish.Droid.Files
{
    public class FileAndroid : ISqlite
    {
        public string GetPathFile()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var dbPath = Path.Combine(path, ConstantsSqlite.NameFile);
            Logs.Logs.Info("Path: " + dbPath);

            return dbPath;
        }
    }
}