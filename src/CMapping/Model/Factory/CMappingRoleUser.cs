
namespace CMapping.Model.Factory
{
    using CAM.Core.Model.Entity;
    using Entity;
    using System;

    public class CMappingRoleUserFactory
    {
        public static CMappingRoleUser createMapping()
        {
            CMappingRoleUser mapping = EntityBuilder.build<CMappingRoleUser>();
            mapping.RoleId = 0;
            mapping.UserId = 0;
            return mapping;
        }
    }
}
