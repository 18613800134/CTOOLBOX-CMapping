
namespace CMapping.Model.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;
    using CAM.Core.Model.Entity;

    public class CMappingOrgRole : BaseEntityNormal
    {
        [Required]
        [Index(IsClustered = false, IsUnique = false)]
        public long OrganizationId { get; set; }

        [Required]
        [Index(IsClustered = false, IsUnique = false)]
        public long RoleId { get; set; }
    }
}
