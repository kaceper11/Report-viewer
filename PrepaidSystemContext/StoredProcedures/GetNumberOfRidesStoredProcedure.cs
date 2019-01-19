using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace PrepaidSystemContext.StoredProcedures
{
    public class GetNumberOfRidesStoredProcedure : StoredProcedure
    {
        public GetNumberOfRidesStoredProcedure(int lineId)
        {
            this.Parameters.Add(new SqlParameter("@lineId", SqlDbType.Int) { Value = lineId });
        }

        protected override string ProcedureName => "[dbo].[GetNumberOfRides]";

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
