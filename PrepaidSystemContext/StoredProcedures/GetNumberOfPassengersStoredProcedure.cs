using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace PrepaidSystemContext.StoredProcedures
{
    public class GetNumberOfPassengersStoredProcedure : StoredProcedure
    {
        public GetNumberOfPassengersStoredProcedure()
        {

        }

        protected override string ProcedureName => "[dbo].[GetNumberOfPassengers]";

        public int ExecuteAndRead(DbConnection connection)
        {
            using (var dataReader = this.ExecuteQuery(connection))
            {
                int numberOfPassengers = 0;

                while (dataReader.Read())
                {
                    numberOfPassengers = dataReader.IsDBNull(0) ? 0 : dataReader.GetInt32(0);
                }

                return numberOfPassengers;
            }
        }
    }
}

