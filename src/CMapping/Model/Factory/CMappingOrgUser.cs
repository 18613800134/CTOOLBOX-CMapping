
namespace CMapping.Model.Factory
{
    using CAM.Core.Model.Entity;
    using Entity;
    using System;

    public class CMappingOrgUserFactory
    {
        public static CMappingOrgUser createMapping()
        {
            CMappingOrgUser mapping = EntityBuilder.build<CMappingOrgUser>();
            mapping.OrganizationId = 0;
            mapping.BranchId = 0;
            mapping.DepartmentId = 0;
            mapping.IsManager = false;
            return mapping;
        }
    }
}
