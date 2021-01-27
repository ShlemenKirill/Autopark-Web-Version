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
    public class VVeniclesRepository : IVVeniclesRepository<VVEnicles>
    {
        readonly IDbConnection connection = null;
        public VVeniclesRepository(string dbConnection)
        {
            connection = new SqlConnection(dbConnection);
        }
        public async Task<IEnumerable<VVEnicles>> GetAll()
        {
            return await connection.QueryAsync<VVEnicles>
                (
                "SELECT " +
                "Venicles.VenicleId, " +
                "VenicleType.VenicleType, " +
                "Venicles.Engine, " +
                "Venicles.ModelName, " +
                "Venicles.RegistrationNumber, " +
                "Venicles.Weight, " +
                "Venicles.Year, " +
                "Venicles.Color, " +
                "Venicles.Mileage, " +
                "Venicles.Tank, " +
                "Venicles.Consumption " +
                "FROM[Venicles] INNER JOIN[VenicleType] " +
                "ON Venicles.VeniclesTypeId = VenicleType.VenicleTypeId"
                );
        }

        public async Task<IEnumerable<VVEnicles>> SortBy(string order)
        {
            var str = order.Split("_");
            if (str.Length == 1)
            {
                return await connection.QueryAsync<VVEnicles>
                (
                "SELECT " +
                "Venicles.VenicleId, " +
                "VenicleType.VenicleType, " +
                "Venicles.Engine, " +
                "Venicles.ModelName, " +
                "Venicles.RegistrationNumber, " +
                "Venicles.Weight, " +
                "Venicles.Year, " +
                "Venicles.Color, " +
                "Venicles.Mileage, " +
                "Venicles.Tank, " +
                "Venicles.Consumption " +
                "FROM[Venicles] INNER JOIN[VenicleType] " +
                "ON Venicles.VeniclesTypeId = VenicleType.VenicleTypeId " +
                "ORDER BY " +  str[0]               
                );
                
            }
            return await connection.QueryAsync<VVEnicles>
                (
                "SELECT " +
                "Venicles.VenicleId, " +
                "VenicleType.VenicleType, " +
                "Venicles.Engine, " +
                "Venicles.ModelName, " +
                "Venicles.RegistrationNumber, " +
                "Venicles.Weight, " +
                "Venicles.Year, " +
                "Venicles.Color, " +
                "Venicles.Mileage, " +
                "Venicles.Tank, " +
                "Venicles.Consumption " +
                "FROM[Venicles] INNER JOIN[VenicleType] " +
                "ON Venicles.VeniclesTypeId = VenicleType.VenicleTypeId " +
                "ORDER BY " + str[0] + " " + str[1]
                );           

        }
    }
}
