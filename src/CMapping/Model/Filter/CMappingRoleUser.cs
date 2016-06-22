
namespace CMapping.Model.Filter
{
    using System;
    using CAM.Core.Model.Entity;
    using CAM.Core.Model.Filter;

    public class CMappingRoleUserFilter: BaseFilter
    {
        public long RoleId { get; set; }
        public long UserId { get; set; }
    }
}
