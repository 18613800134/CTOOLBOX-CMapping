
namespace CMapping.Business.Interface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CAM.Core.Business.Interface;
    using Model.Entity;
    using Model.Filter;
    using DBContext;

    public interface ICMappingRoleUserCommand : IBaseInterfaceCommand<DBContextCMapping>
    {
        void addMappingRoleUser(long RoleId, long UserId);
        void updateMappingRoleUser(long RoleId, long UserId, long ToRoleId, long ToUserId);
        void updateMappingRoleUser(long Id, long ToRoleId, long ToUserId);
        void deleteMappingRoleUser(long RoleId, long UserId);
        void deleteMappingRoleUser(long Id);
    }
}
