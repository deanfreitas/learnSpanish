using System;
using System.IO;
using learnSpanish.Constants;
using learnSpanish.iOS.Files;
using learnSpanish.Sqlite.Interface;
using Xamarin.Forms;


[assembly: Dependency(typeof(FileIOS))]

namespace learnSpanish.iOS.Files
{
    public class FileIOS : ISqlite
    {
        public string GetPathFile()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var dbPath = Path.Combine(path, "..", "Library", ConstantsSqlite.NameFile);
            Logs.Logs.Error("Path: " + dbPath);

            if (File.Exists(dbPath)) return dbPath;

            File.Create(dbPath);

            return dbPath;
        }
    }
}