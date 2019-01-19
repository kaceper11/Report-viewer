using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace PrepaidSystemContext
{
    public abstract class StoredProcedure
    {
        protected StoredProcedure()
        {
            this.Parameters =  new List<SqlParameter>();
        }

        protected abstract string ProcedureName { get; }

        protected List<SqlParameter> Parameters { get; set; }

        public int ExecuteNonQuery(DbConnection dbConnection, SqlTransaction transaction, int commandTimeout = 30)
        {
            if (dbConnection.State == ConnectionState.Closed)
            {
                dbConnection.Open();
            }

            var cmd = dbConnection.CreateCommand();
            cmd.CommandText = this.ProcedureName;
            cmd.CommandType = CommandType.StoredProcedure;

            if (transaction != null)
            {
                cmd.Transaction = transaction;
            }

            cmd.CommandTimeout = commandTimeout;
            cmd.Parameters.AddRange(this.Parameters.ToArray());

            return cmd.ExecuteNonQuery();
        }

        public int ExecuteNonQuery(SqlConnection sqlConnection)
        {
            return this.ExecuteNonQuery(sqlConnection, null);
        }

        public DbDataReader ExecuteQuery(DbConnection dbConnection, int CommandTimeout = 7200)
        {
            if (dbConnection.State == ConnectionState.Closed)
            {
                dbConnection.Open();
            }

            var cmd = dbConnection.CreateCommand();
            cmd.CommandText = this.ProcedureName;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandTimeout = CommandTimeout;
            cmd.Parameters.AddRange(this.Parameters.ToArray());
            return cmd.ExecuteReader();
        }
    }
}
