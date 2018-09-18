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
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string dbPath = Path.Combine(path, ConstantsSQLite.NameFile);
            Logs.Logs.Error("Path: " + dbPath);

            if (File.Exists(dbPath)) return dbPath;

            try
            {
                File.Create(dbPath);
            }
            catch (Exception e)
            {
                Logs.Logs.Error("Error to create file Db --> " + e.Message);
            }

            return dbPath;
        }
    }
}