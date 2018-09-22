using System;
using learnSpanish.Enums.Service;
using learnSpanish.Enums.Sql;

namespace learnSpanish.Exceptions
{
    [Serializable()]
    public class SqliteServiceException : Exception
    {
        public SqliteServiceException(TableSql tableSql, string table, string errorMessage) : base(
            EnumsService.GetMessageErrorSqlService(tableSql, table, errorMessage))
        {
        }

        public SqliteServiceException(TableSql tableSql, string table, Exception innerException) : base(
            EnumsService.GetMessageErrorSqlService(tableSql, table, innerException.Message))
        {
        }
    }
}