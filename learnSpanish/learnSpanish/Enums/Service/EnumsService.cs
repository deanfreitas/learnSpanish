using System;
using learnSpanish.Enums.Error;
using learnSpanish.Enums.Sql;

namespace learnSpanish.Enums.Service
{
    public class EnumsService
    {
        public static string GetMessageErrorUser(ErrorUser errorUser)
        {
            switch (errorUser)
            {
                case ErrorUser.WrongCredentials: return "Your user or password is wrong";
                default: throw new ArgumentOutOfRangeException(nameof(errorUser), errorUser, null);
            }
        }

        public static string GetMessageErrorSystem(ErrorSystem errorSystem)
        {
            switch (errorSystem)
            {
                case ErrorSystem.Generic: return "Error system";
                default: throw new ArgumentOutOfRangeException(nameof(errorSystem), errorSystem, null);
            }
        }

        public static string GetMessageErrorSqlService(TableSql tableSql, string table, string errorMessage)
        {
            string interactionTable;

            switch (tableSql)
            {
                case TableSql.Insert:
                    interactionTable = "insert";
                    break;
                case TableSql.Select:
                    interactionTable = "select";
                    break;
                case TableSql.Update:
                    interactionTable = "update";
                    break;
                case TableSql.Delete:
                    interactionTable = "Delete";
                    break;
                default: throw new ArgumentOutOfRangeException(nameof(tableSql), tableSql, null);
            }

            return string.Format($"Error {interactionTable} table {table}: {errorMessage}");
        }
    }
}