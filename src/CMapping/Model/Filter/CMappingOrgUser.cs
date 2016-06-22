
namespace CMapping.Model.Filter
{
    using System;
    using CAM.Core.Model.Entity;
    using CAM.Core.Model.Filter;

    public class CMappingOrgUserFilter: BaseFilter
    {
        public long OrganizationId { get; set; }
        public long UserId { get; set; }
    }
}
