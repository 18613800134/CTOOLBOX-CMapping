
namespace CMapping.Model.Factory
{
    using CAM.Core.Model.Entity;
    using Entity;
    using System;

    public class CMappingOrgRoleFactory
    {
        public static CMappingOrgRole createMapping()
        {
            CMappingOrgRole mapping = EntityBuilder.build<CMappingOrgRole>();
            mapping.OrganizationId = 0;
            mapping.RoleId = 0;
            return mapping;
        }
    }
}
