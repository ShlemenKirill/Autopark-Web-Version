using Autopark_Web_Version.Models.Interfaces;
using Autopark_Web_Version.Models.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Autopark_Web_Version.Models.Repositories
{
    public class VOrdersRepository : IReadOnlyRepository<VOrders>
    {
        readonly IDbConnection connection = null;
        public VOrdersRepository(string dbConnection)
        {
            connection = new SqlConnection(dbConnection);
        }
        public IEnumerable<VOrders> GetAll()
        {
            return connection.Query<VOrders>
                (
                "SELECT " +
                "Orders.OrderId, " +
                "(Venicles.ModelName + ' ' + Venicles.RegistrationNumber) as VenicleName, " +
                "Orders.Date " +
                "FROM[Orders] INNER JOIN[Venicles] " +
                "ON Orders.VenicleId = Venicles.VenicleId"
                ).ToList();
        }
    }
}
