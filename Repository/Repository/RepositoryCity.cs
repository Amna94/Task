using Amna.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Amna.Repository
{
    public class RepositoryCity : IGenericRepository<City>, IRepositoryCity
    {
        protected readonly IConfiguration _configuration;
        public RepositoryCity(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        public IDbConnection Connection
        {
            get
            {
                return new Npgsql.NpgsqlConnection(_configuration.GetConnectionString("Database"));

            }
        }
        public void Add(City cities)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"INSERT INTO cities(name,country_id) VALUES(@Name,@CountryId)";
                    dbConnection.Execute(query, cities);
                    dbConnection.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"DELETE FROM cities WHERE id = @Id";
                    dbConnection.Execute(query, new { id });
                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<City> GetAll()
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT * FROM cities";
                    return dbConnection.Query<City>(query);
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        public City GetById(int id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT FROM cities WHERE CityId = @CityId ";
                    return dbConnection.QueryFirstOrDefault<City>(query, new { CityId = id });                
                }

            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Update(City item)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"UPDATE cities SET Name = @Name";
                    dbConnection.Execute(query, item);
                }

            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
