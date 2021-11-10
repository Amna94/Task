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
    public class RepositoryUsers : IGenericRepository<Users>, IRepositoryUsers
    {
        protected readonly IConfiguration _configuration;
        public RepositoryUsers(IConfiguration configuration)
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

        public void Add(Users users)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"INSERT INTO users (first_name, last_name, username, password, e_mail, phone_number, city_id, role_id) VALUES(@FirstName, @LastName, @Username, @Password, @Email, @PhoneNumber, @CityId, @RoleId) ";
                    dbConnection.Execute(query, users);
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
                    string query = @"DELETE FROM users WHERE id = @Id";
                    dbConnection.Execute(query, new { id });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Users> GetAll()
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT * FROM users";
                    return dbConnection.Query<Users>(query);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Users GetById(int id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT * FROM users WHERE id = @Id ";
                    return dbConnection.QueryFirstOrDefault<Users>(query, new { Id = id });
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Users users)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"UPDATE users SET first_name = @FirstName WHERE id=@Id";
                    dbConnection.Execute(query, users);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
