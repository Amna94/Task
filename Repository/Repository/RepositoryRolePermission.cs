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
    public class RepositoryRolePermission : IGenericRepository<RolePermission>, IRepositoryRolePermission
    {
        protected readonly IConfiguration _configuration;
        public RepositoryRolePermission(IConfiguration configuration)
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

        public void Add(RolePermission rolePermission)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"INSERT INTO rolepermissions(role_id,permission_id) VALUES(@RoleId,@PermissionId) ";
                    dbConnection.Execute(query, rolePermission);
                    dbConnection.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //public void Add(RolePermission rolePermission)
        //{
        //    try
        //    {
        //        using (IDbConnection dbConnection = Connection)
        //        {
        //            dbConnection.Open();
        //            string query = @"INSERT INTO role_permissions";
        //            dbConnection.Execute(query, rolePermission);
        //            dbConnection.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {

            //        throw ex;
            //    }
            //}

            public void Delete(string id, string Id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"DELETE FROM rolepermissions WHERE role_id = @RoleId, permission_id = @PermissionId";
                    dbConnection.Execute(query, new { RoleId = id, PermissionId = Id });
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

        public IEnumerable<RolePermission> GetAll()
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT * FROM rolepermissions";
                    return dbConnection.Query<RolePermission>(query);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public RolePermission GetById(string id, string Id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT FROM rolepermissions WHERE role_id = @RoleId, permission_id = @PermissionId";
                    return dbConnection.QueryFirstOrDefault<RolePermission>(query, new { RoleId = id, PermissionId = Id });
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public RolePermission GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(RolePermission rolePermission)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"UPDATE rolepermissions SET permission_id = @PermissionId WHERE role_id = @RoleId";
                    dbConnection.Execute(query, rolePermission);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}
