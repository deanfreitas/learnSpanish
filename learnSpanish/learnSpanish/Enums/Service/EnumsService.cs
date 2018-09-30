using System;
using learnSpanish.Enums.Error;
using learnSpanish.Enums.Sql;
using learnSpanish.Enums.Success;

namespace learnSpanish.Enums.Service
{
    public class EnumsService
    {
        public static string GetMessageErrorUser(ErrorUser user)
        {
            switch (user)
            {
                case ErrorUser.WrongCredentials: return "Your user or password is wrong";
                case ErrorUser.WrongEmail: return "Email in the wrong format";
                case ErrorUser.UnconfirmedPassword: return "Password has not been confirmed";
                case ErrorUser.ExistEmail: return "This email is already registered";
                case ErrorUser.ExistUserName: return "This user is already registered";
                default: throw new ArgumentOutOfRangeException(nameof(user), user, null);
            }
        }

        public static string GetMessageErrorSystem(ErrorSystem system)
        {
            switch (system)
            {
                case ErrorSystem.Generic: return "Error system";
                default: throw new ArgumentOutOfRangeException(nameof(system), system, null);
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

        public static string GetMessageSuccessUser(SuccessUser user, string nameUser)
        {
            switch (user)
            {
                case SuccessUser.UserRegistered: return $"{nameUser} was registered with success";
                default: throw new ArgumentOutOfRangeException(nameof(user), user, null);
            }
        }
    }
}