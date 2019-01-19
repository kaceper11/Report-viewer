using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Data.Common;

namespace PrepaidSystemContext.StoredProcedures
{
    public class GetBalanceChangeInPeriodStoredProcedure : StoredProcedure
    {
        public GetBalanceChangeInPeriodStoredProcedure(DateTime startDate, DateTime endDate)
        {
            this.Parameters.Add(new SqlParameter("@startDate", SqlDbType.DateTime2) {Value = startDate});
            this.Parameters.Add(new SqlParameter("@endDate", SqlDbType.DateTime2) {Value = endDate});
        }

        protected override string ProcedureName => "[dbo].[GetBalanceChangeInPeriod]";

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
