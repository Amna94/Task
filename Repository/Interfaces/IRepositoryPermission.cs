using Amna.Repository;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amna.Interfaces
{
    public interface IRepositoryPermission : IGenericRepository<Permission>
    {
        string GetById(string permissionsId);
        void Delete(string permissionsId);
    }
}
