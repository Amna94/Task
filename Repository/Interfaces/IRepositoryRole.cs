using Amna.Repository;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amna.Interfaces
{
    public interface IRepositoryRole : IGenericRepository<Role>
    {
        Role GetById(string rolesId);
        void Delete(string rolesId);
    }
}
