using Repository.Models;

namespace Amna.Repository
{
    public interface IRepositoryRolePermission: IGenericRepository<RolePermission>
    {
        
        
        RolePermission GetById(string roleId, string permissionId);
        void Delete(string roleId, string permissionId);
    }
}