using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Models
{
    [Table("role_permissions")]
    public class RolePermission
    {
       
        
        [Column("role_id")]
        public string RoleId { get; set; }
        [Column ("permission_id")]
        public string PermissionId { get; set; }
    }
}
