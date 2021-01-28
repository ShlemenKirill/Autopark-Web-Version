using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Autopark_Web_Version.Models.Repositories
{
    public class VenicleRepository : IVenicleRepository<Venicles>, IDisposable
    {
        readonly IDbConnection connection = null;
        public VenicleRepository(string dbConnection)
        {
            connection = new SqlConnection(dbConnection);
        }
        
        public async Task<IEnumerable<Venicles>> GetAll()
        {            
            return await connection.QueryAsync<Venicles>("SELECT * FROM Venicles");
            
        }
        public async Task Create(Venicles entity)
        {
            
            var sqlQuery = $"INSERT INTO Venicles (VeniclesTypeId, Engine, ModelName,RegistrationNumber, Weight, Year, Color, Mileage,Tank, Consumption) " +
                            "VALUES(@VeniclesTypeId, @Engine, @ModelName, @RegistrationNumber, @Weight, @Year, @Color, @Mileage, @Tank, @Consumption)";
            await connection.ExecuteAsync(sqlQuery, entity);
            
        }

        public async Task Delete(int id)
        {            
            var sqlQuery = "DELETE FROM Venicles WHERE VenicleId = @id";
            await connection.ExecuteAsync(sqlQuery, new { id });            
        }

        public async Task<Venicles> Get(int id)
        {
            IEnumerable<Venicles> venicleById =  await connection.QueryAsync<Venicles>("SELECT * FROM Venicles WHERE VenicleId = @id", new { id });
            return venicleById.FirstOrDefault();
        }

        public async Task Update(Venicles entity)
        {
            
            var sqlQuery = "UPDATE Venicles SET " +
                            "VeniclesTypeId = @VeniclesTypeId, " +
                            "Engine = @Engine, " +
                            "ModelName = @ModelName, " +
                            "RegistrationNumber = @RegistrationNumber, " +
                            "Weight = @Weight, " +
                            "Year = @Year, " +
                            "Color = @Color, " +
                            "Mileage = @Mileage, " +
                            "Tank = @Tank, " +
                            "Consumption = @Consumption " +
                            "WHERE VenicleId = @VenicleId";
            await connection.ExecuteAsync(sqlQuery, entity);                
            
        }

        public async Task<IEnumerable<Venicles>> SortBy(string order)
        {
            var str = order.Split("_");
            if (str.Length == 1)
            {
                return await connection.QueryAsync<Venicles>($"SELECT * FROM Venicles ORDER BY {str[0]}");
            }
            return await connection.QueryAsync<Venicles>($"SELECT * FROM Venicles ORDER BY {str[0]} {str[1]}");              
            
        }

        public async Task<double> CalculateTaxPerMounth(int id)
        {
            var venicles = await connection.QueryAsync<Venicles>("SELECT * FROM Venicles WHERE VenicleId = @id", new { id });
            var venicle = venicles.FirstOrDefault();
            var veniclesTypeTax = await connection.QueryAsync<VenicleType>($"SELECT * FROM VenicleType WHERE VenicleTypeId ={venicle.VeniclesTypeId}");
            var venicleTypeTax = veniclesTypeTax.FirstOrDefault();
            var venicleEngine = venicle.Engine;
            double engineTax = 0;
            switch (venicleEngine)
            {
                case "diesel": 
                    engineTax = 1.2;
                    break;
                case "gasoline":
                    engineTax = 1;
                    break;
                case "electric":
                    engineTax = 0.1;
                    break;
            }
            return (venicle.Weight * 0.013) + (venicleTypeTax.VenicleTax * engineTax * 30.0) + 5;
        }

        public async Task<double> CalculateMaxKilometers(int id)
        {
            var venicles = await connection.QueryAsync<Venicles>("SELECT * FROM Venicles WHERE VenicleId = @id", new { id });
            var venicle = venicles.FirstOrDefault();

            return venicle.Tank / venicle.Consumption * 100 ; 
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

        ~VenicleRepository()
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
