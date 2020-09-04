using Dapper;
using MAB.Models;
using MAB.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MAB.DataAccess
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(string connectionString) : base(connectionString)
        {

        }

        // Ejecutar el SP
        public IEnumerable<CustomerList> CustumersPagedList(int page, int rows)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@page", page);
            parameters.Add("@rows", rows);

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    return connection.Query<CustomerList>("dbo.CustomerPagedList",
                                                      parameters,
                                                      commandType: System.Data.CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Error: {0}", ex);
            }
        }
    }
}
