using Amna.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Amna.Repository
{
    public class RepositoryCountry : IGenericRepository<Country>, IRepositoryCountry
    {
        protected readonly IConfiguration _configuration;
        public RepositoryCountry(IConfiguration configuration)
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

        public void Add(Country countries)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"INSERT INTO countries(Name) VALUES(@Name)";
                    dbConnection.Execute(query, countries);
                    dbConnection.Close();
                }
            }catch(Exception ex)
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
                    string query = @"DELETE FROM countries WHERE id = @Id";
                    dbConnection.Execute(query, new { id });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Country> GetAll()
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT * FROM countries";
                    return dbConnection.Query<Country>(query);
                }

            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public Country GetById(int id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT FROM countries WHERE CountryId = @CountryId ";
                    return dbConnection.QueryFirstOrDefault<Country>(query, new { CountryId = id });
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Country countries)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"UPDATE countries SET Name = @Name WHERE id=@Id";
                    dbConnection.Execute(query, countries);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
