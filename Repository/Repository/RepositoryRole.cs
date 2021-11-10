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
    public class RepositoryRole : IGenericRepository<Role>, IRepositoryRole
    {
        protected readonly IConfiguration _configuration;
        public RepositoryRole(IConfiguration configuration)
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
        
        public void Add(Role role)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"INSERT INTO roles(id,description) VALUES(@Id,@Description)";
                    dbConnection.Execute(query, role);
                    dbConnection.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Delete(string id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"DELETE FROM roles WHERE id = @Id";
                    dbConnection.Execute(query, new { id });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Role> GetAll()
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT * FROM roles";
                    return dbConnection.Query<Role>(query);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Role GetById(string id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT FROM roles WHERE roles_id = @RoleId ";
                    return dbConnection.QueryFirstOrDefault<Role>(query, new { roles_id = id });
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Role GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Role role)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"UPDATE roles SET description = @Description WHERE id=@Id";
                    dbConnection.Execute(query, role);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
