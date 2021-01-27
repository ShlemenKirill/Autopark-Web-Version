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
    public class OrderDetailsRepository : IOrderDetailsRepository<OrderDetails>, IDisposable
    {
        readonly IDbConnection connection = null;
        public OrderDetailsRepository(string dbConnection)
        {
            connection = new SqlConnection(dbConnection);
        }
        public async Task Create(OrderDetails entity)
        {
            var sqlQuery = $"INSERT INTO OrderDetails (OrderId, VenicleId, DetailId, Quantity) " +
                            "VALUES(@OrderId, @VenicleId, @DetailId, @Quantity)";
            await connection.ExecuteAsync(sqlQuery, entity);
        }

        public async Task<IEnumerable<OrderDetails>> GetAllByOrderId(int id)
        {
            return await connection.QueryAsync<OrderDetails>("SELECT * FROM OrderDetails WHERE OrderId = @id", new { id });
        }        

        #region Disposable

        private bool _disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (_disposedValue)
            {
                return;
            }

            if (disposing)
            {
                connection.Dispose();
            }

            _disposedValue = true;
        }

        ~OrderDetailsRepository()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion Disposable
    }
}
