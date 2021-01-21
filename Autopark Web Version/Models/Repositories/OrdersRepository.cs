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
    public class OrdersRepository : IOrdersRepository<Orders>, IDisposable
    {
        readonly IDbConnection connection = null;
        public OrdersRepository(string dbConnection)
        {
            connection = new SqlConnection(dbConnection);
        }     

        public List<Orders> GetAll()
        {
            return connection.Query<Orders>("SELECT * FROM Orders").ToList();
            
        }
        public void Create(Orders entity)
        {
            var sqlQuery = $"INSERT INTO Orders (VenicleId, Date) " +
                            "VALUES(@VenicleId, @Date)";
            connection.Execute(sqlQuery, entity);
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

        ~OrdersRepository()
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
