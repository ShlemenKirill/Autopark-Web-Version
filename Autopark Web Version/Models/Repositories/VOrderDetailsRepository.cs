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
    public class VOrderDetailsRepository : IVOrderDetailsRepository<VOrderDetails>
    {
        readonly IDbConnection connection = null;
        public VOrderDetailsRepository(string dbConnection)
        {
            connection = new SqlConnection(dbConnection);
        }
        public IEnumerable<VOrderDetails> GetAllById(int id)
        {
            return connection.Query<VOrderDetails>
                (
                "SELECT " +
                "OrderDetails.OrderDetailId, " +
                "OrderDetails.OrderId, " +
                "Venicles.ModelName + ' ' + Venicles.RegistrationNumber AS VenicleName, " +
                "Details.DetailName, " +
                "OrderDetails.Quantity " +
                "FROM[OrderDetails] INNER JOIN[Details] " +
                "ON OrderDetails.OrderDetailId = Details.DetailId " +
                "INNER JOIN[Venicles] " +
                "ON OrderDetails.VenicleId = Venicles.VenicleId " +
                "WHERE OrderId = @id"
                , new { id }
                ).ToList();
        }
    }
}
