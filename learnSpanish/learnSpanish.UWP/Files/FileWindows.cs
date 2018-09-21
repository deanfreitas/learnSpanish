using System;
using System.IO;
using Windows.Storage;
using learnSpanish.Constants;
using learnSpanish.Sqlite.Interface;
using learnSpanish.UWP.Files;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileWindows))]

namespace learnSpanish.UWP.Files
{
    public class FileWindows : ISqlite
    {
        public string GetPathFile()
        {
            var path = ApplicationData.Current.LocalFolder.Path;
            var dbPath = Path.Combine(path, ConstantsSQLite.NameFile);
            Logs.Logs.Error("Path: " + dbPath);

            if (File.Exists(dbPath)) return dbPath;

            File.Create(dbPath);

            return dbPath;
        }
    }
}