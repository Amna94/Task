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
    public class RepositoryPermission : IGenericRepository<Permission>, IRepositoryPermission
    {
        protected readonly IConfiguration _configuration;

        public RepositoryPermission(IConfiguration configuration)
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
        public void Add(Permission permission)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"INSERT INTO permissions(id, description) VALUES(@Id, @Description)";
                    dbConnection.Execute(query, permission);
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
                    string query = @"DELETE FROM permissions WHERE id = @Id";
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

        public IEnumerable<Permission> GetAll()
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT * FROM permissions";
                    return dbConnection.Query<Permission>(query);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Permission GetById(string id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT FROM permissions WHERE PermissionsId = @PermissionsId ";
                    return dbConnection.QueryFirstOrDefault<Permission>(query, new { PermissionsId = id });
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Permission GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Permission permission)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"UPDATE permissions SET Description = @Description WHERE id=@Id";
                    dbConnection.Execute(query, permission);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        string IRepositoryPermission.GetById(string permissionsId)
        {
            throw new NotImplementedException();
        }
    }
}
