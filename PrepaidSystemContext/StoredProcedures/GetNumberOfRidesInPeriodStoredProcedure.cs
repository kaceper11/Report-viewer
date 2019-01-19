using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace PrepaidSystemContext.StoredProcedures
{
    public class GetNumberOfRidesInPeriodStoredProcedure : StoredProcedure
    {
        public  GetNumberOfRidesInPeriodStoredProcedure(int lineId, DateTime startDate, DateTime endDate)
        {
            this.Parameters.Add(new SqlParameter("@lineId", SqlDbType.Int) { Value = lineId });
            this.Parameters.Add(new SqlParameter("@startDate", SqlDbType.DateTime2) { Value = startDate });
            this.Parameters.Add(new SqlParameter("@endDate", SqlDbType.DateTime2) { Value = endDate });
        }

        protected override string ProcedureName => "[dbo].[GetNumberOfRidesInPeriod]";

        public int ExecuteAndRead(DbConnection connection)
        {
            using (var dataReader = this.ExecuteQuery(connection))
            {
                int numberOfRides = 0;

                while (dataReader.Read())
                {
                    numberOfRides = dataReader.IsDBNull(0) ? 0 : dataReader.GetInt32(0);
                }

                return numberOfRides;
            }
        }
    }
}
