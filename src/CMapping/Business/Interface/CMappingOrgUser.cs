
namespace CMapping.Business.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CAM.Core.Business.Interface;
    using Model.Entity;
    using Model.Filter;
    using DBContext;

    public interface ICMappingOrgUserCommand :IBaseInterfaceCommand<DBContextCMapping>
    {
        void addMappingOrgUser(long OrganizationId, long BranchId, long DepartmentId, long UserId, bool IsManager);
        void updateMappingOrgUser(long OrganizationId, long UserId, long ToBranchId, long ToDepartmentId);
        void updateMappingOrgUser(long Id, long ToBranchId, long ToDepartmentId);
        void deleteMappingOrgUser(long OrganizationId, long UserId);
        void deleteMappingOrgUser(long Id);
    }
}
