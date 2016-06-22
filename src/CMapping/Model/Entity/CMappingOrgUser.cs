
namespace CMapping.Model.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;
    using CAM.Core.Model.Entity;

    public class CMappingOrgUser : BaseEntityNormal
    {
        [Required]
        [Index(IsClustered = false, IsUnique = false)]
        public long OrganizationId { get; set; }

        [Required]
        [Index(IsClustered = false, IsUnique = false)]
        public long BranchId { get; set; }

        [Required]
        [Index(IsClustered = false, IsUnique = false)]
        public long DepartmentId { get; set; }

        [Required]
        [Index(IsClustered = false, IsUnique = false)]
        public long UserId { get; set; }

        /// <summary>
        /// 是否是该企业的拥有者（超级管理员）
        /// </summary>
        [Required]
        [Index(IsClustered = false, IsUnique = false)]
        public bool IsManager { get; set; }
    }
}
