using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Autopark_Web_Version.Models.Repositories
{
    public class VenicleTypeRepository : IVenicleTypeRepository<VenicleType>, IDisposable
    {        
        readonly IDbConnection connection = null;
        public VenicleTypeRepository(string dbConnection)
        {
            connection = new SqlConnection(dbConnection);
        }
        public async Task<IEnumerable<VenicleType>> GetAll()
        {            
            return await connection.QueryAsync<VenicleType>("SELECT * FROM VenicleType");
        }
        public async Task Create(VenicleType entity)
        {
            
            var sqlQuery = "INSERT INTO Venicles (Engine, ModelName,RegistrationNumber, Weight, Year, Color, Mileage,Tank) " +
                "VALUES(@Engine, @ModelName, @RegistrationNumber, @Weight, @Year, @Color, @Mileage, @Tank)";
            await connection.ExecuteAsync(sqlQuery, entity);
        }

        public async Task Delete(int id)
        {            
            var sqlQuery = "DELETE FROM Venicles WHERE Id = @id";
            await connection.ExecuteAsync(sqlQuery, new { id });
        }

        public async Task<VenicleType> Get(int id)
        {            
            var getVenicleTypeById =  await connection.QueryAsync<VenicleType>("SELECT * FROM Venicles WHERE Id = @id", new { id });
            return getVenicleTypeById.FirstOrDefault();
        }

        public async Task Update(VenicleType entity)
        {            
            var sqlQuery = "UPDATE Users SET Name = @Name, Age = @Age WHERE Id = @Id";
            await connection.ExecuteAsync(sqlQuery, entity);
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

        ~VenicleTypeRepository()
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
