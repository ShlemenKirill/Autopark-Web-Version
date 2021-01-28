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
    public class VOrderDetailsRepository : IVOrderDetailsRepository<VOrderDetails>, IDisposable
    {
        readonly IDbConnection connection = null;
        public VOrderDetailsRepository(string dbConnection)
        {
            connection = new SqlConnection(dbConnection);
        }
        public async Task<IEnumerable<VOrderDetails>> GetAllById(int id)
        {
            
            return await connection.QueryAsync<VOrderDetails>
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
                "WHERE OrderId = @id", new { id }               
                );
            
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

        ~VOrderDetailsRepository()
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
