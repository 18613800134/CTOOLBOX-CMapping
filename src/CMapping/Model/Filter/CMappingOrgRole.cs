
namespace CMapping.Model.Filter
{
    using System;
    using CAM.Core.Model.Entity;
    using CAM.Core.Model.Filter;

    public class CMappingOrgRoleFilter:BaseFilter
    {
        public long OrganizationId { get; set; }
        public long RoleId { get; set; }
    }
}
