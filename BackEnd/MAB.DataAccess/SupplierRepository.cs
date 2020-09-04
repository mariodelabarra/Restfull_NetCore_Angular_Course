using Dapper;
using MAB.Models;
using MAB.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MAB.DataAccess
{
    public class SupplierRepository : Repository<Models.Supplier>, ISupplierRepository
    {
        public SupplierRepository(string connectionString) : base(connectionString)
        {

        }
        public IEnumerable<Supplier> SupplierPagedList(int page, int rows, string searchTerm)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@page", page);
            parameters.Add("@rows", rows);
            parameters.Add("@searchTerm", searchTerm);

            using(var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Supplier>("dbo.SupplierPagedList",
                                                   parameters,
                                                   commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
