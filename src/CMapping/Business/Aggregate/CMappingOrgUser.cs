
namespace CMapping.Business.Aggregate
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Data.Entity.SqlServer;
    using System.Collections.Generic;

    using Model.Entity;
    using Model.Factory;
    using Model.Filter;

    using CAM.Core.Model.Entity;
    using CAM.Core.Business.Interface;
    using CAM.Core.Business.Aggregate;

    using Interface;
    using Rule;

    using CAM.Common.Data;
    using CAM.Common.Error;

    public partial class Aggregate : ICMappingOrgUserCommand
    {

        public void addMappingOrgUser(long OrganizationId, long BranchId, long DepartmentId, long UserId, bool IsManager)
        {
            try
            {
                IRepository<CMappingOrgUser> res = createRepository<CMappingOrgUser>();
                CMappingOrgUser dbObj = CMappingOrgUserFactory.createMapping();

                dbObj.OrganizationId = OrganizationId;
                dbObj.BranchId = BranchId;
                dbObj.DepartmentId = DepartmentId;
                dbObj.UserId = UserId;
                dbObj.IsManager = IsManager;

                dbObj.addValidationRule(new MappingOrgUserCannotWithOutOrgOrUserRule(res, dbObj));

                dbObj.validate();
                res.add(dbObj);

                commit();

            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }

        public void updateMappingOrgUser(long OrganizationId, long UserId, long ToBranchId, long ToDepartmentId)
        {
            try
            {
                IRepository<CMappingOrgUser> res = createRepository<CMappingOrgUser>();
                CMappingOrgUser dbObj = res.read(m => m.OrganizationId == OrganizationId && m.UserId == UserId);

                dbObj.BranchId = ToBranchId;
                dbObj.DepartmentId = ToDepartmentId;

                dbObj.validate();
                res.update(dbObj);

                commit();

            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }

        public void updateMappingOrgUser(long Id, long ToBranchId, long ToDepartmentId)
        {
            try
            {
                IRepository<CMappingOrgUser> res = createRepository<CMappingOrgUser>();
                CMappingOrgUser dbObj = res.read(m => m.Id == Id);

                dbObj.BranchId = ToBranchId;
                dbObj.DepartmentId = ToDepartmentId;

                dbObj.validate();
                res.update(dbObj);

                commit();

            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }

        public void deleteMappingOrgUser(long OrganizationId, long UserId)
        {
            try
            {
                IRepository<CMappingOrgUser> res = createRepository<CMappingOrgUser>();
                CMappingOrgUser dbObj = res.read(m => m.OrganizationId == OrganizationId && m.UserId == UserId);

                deleteMappingOrgUser(dbObj.Id);
            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }

        public void deleteMappingOrgUser(long Id)
        {
            try
            {
                IRepository<CMappingOrgUser> res = createRepository<CMappingOrgUser>();

                res.delete(typeof(CMappingOrgUser), Id.ToString());

                commit();
            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }
    }
}
