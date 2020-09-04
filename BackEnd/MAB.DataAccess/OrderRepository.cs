using Dapper;
using MAB.Models;
using MAB.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MAB.DataAccess
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(string connectionString): base(connectionString)
        {

        }

        public IEnumerable<OrderList> GetPaginatedOrder(int page, int rows)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@page", page);
            parameters.Add("@rows", rows);

            using (var connection = new SqlConnection(_connectionString))
            {
                var reader = connection.QueryMultiple("dbo.get_paginated_orders",
                                                   parameters,
                                                   commandType: System.Data.CommandType.StoredProcedure);

                var orderList = reader.Read<OrderList>().ToList();
                var orderItemList = reader.Read<OrderItemList>().ToList();
                
                foreach(var item in orderList) item.SetDetails(orderItemList);

                return orderList;
            }
        }
    }
}
