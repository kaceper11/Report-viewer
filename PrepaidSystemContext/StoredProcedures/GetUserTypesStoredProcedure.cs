using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Data.SqlClient;

namespace PrepaidSystemContext.StoredProcedures
{
    public class GetUserTypesStoredProcedure : StoredProcedure
    {
        public GetUserTypesStoredProcedure(int roleTypeId)
        {
            this.Parameters.Add(new SqlParameter("@roleTypeId", SqlDbType.Int) { Value = roleTypeId });
        }

        protected override string ProcedureName => "[dbo].[GetUserTypes]";

        public int ExecuteAndRead(DbConnection connection)
        {
            using (var dataReader = this.ExecuteQuery(connection))
            {
                int numberOfUsers = 0;

                while (dataReader.Read())
                {
                    numberOfUsers = dataReader.IsDBNull(0) ? 0 : dataReader.GetInt32(0);
                }

                return numberOfUsers;
            }
        }
    }
}

