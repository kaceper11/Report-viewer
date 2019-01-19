using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Data.SqlClient;

namespace PrepaidSystemContext.StoredProcedures
{
    public class GetBalanceChangeStoredProcedure : StoredProcedure
    {
        public GetBalanceChangeStoredProcedure()
        {

        }

        protected override string ProcedureName => "[dbo].[GetBalanceChange]";

        public decimal ExecuteAndRead(DbConnection connection)
        {
            using (var dataReader = this.ExecuteQuery(connection))
            {
                decimal balance = 0;

                while (dataReader.Read())
                {
                    balance = dataReader.IsDBNull(0) ? 0 : dataReader.GetDecimal(0);
                }

                return balance;
            }
        }
    }
}
