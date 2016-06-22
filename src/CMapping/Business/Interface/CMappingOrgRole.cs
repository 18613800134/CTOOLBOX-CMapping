
namespace CMapping.Business.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CAM.Core.Business.Interface;
    using Model.Entity;
    using Model.Filter;
    using DBContext;

    public interface ICMappingOrgRoleCommand : IBaseInterfaceCommand<DBContextCMapping>
    {
        void addMappingOrgRole(long OrganizationId, long RoleId);
        void updateMappingOrgRole(long OrganizationId, long RoleId, long ToOrganizationId, long ToRoleId);
        void updateMappingOrgRole(long Id, long ToOrganizationId, long ToRoleId);
        void deleteMappingOrgRole(long OrganizationId, long RoleId);
        void deleteMappingOrgRole(long Id);

    }
}
