
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

    public partial class Aggregate : ICMappingRoleUserCommand
    {

        public void addMappingRoleUser(long RoleId, long UserId)
        {
            try
            {
                IRepository<CMappingRoleUser> res = createRepository<CMappingRoleUser>();
                CMappingRoleUser dbObj = CMappingRoleUserFactory.createMapping();

                dbObj.RoleId = RoleId;
                dbObj.UserId = UserId;

                dbObj.addValidationRule(new MappingRoleUserCannotWithOutRoleOrUserRule(res, dbObj));
                dbObj.addValidationRule(new MappingRoleUserCannotExistsSameMappingRule(res, dbObj));

                dbObj.validate();
                res.add(dbObj);

                commit();

            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }

        public void updateMappingRoleUser(long RoleId, long UserId, long ToRoleId, long ToUserId)
        {
            try
            {
                IRepository<CMappingRoleUser> res = createRepository<CMappingRoleUser>();
                CMappingRoleUser dbObj = res.read(m => m.RoleId == RoleId && m.UserId == UserId);

                dbObj.RoleId = ToRoleId;
                dbObj.UserId = ToUserId;

                dbObj.addValidationRule(new MappingRoleUserCannotWithOutRoleOrUserRule(res, dbObj));
                dbObj.addValidationRule(new MappingRoleUserCannotExistsSameMappingRule(res, dbObj));

                dbObj.validate();
                res.update(dbObj);

                commit();

            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }

        public void updateMappingRoleUser(long Id, long ToRoleId, long ToUserId)
        {
            try
            {
                IRepository<CMappingRoleUser> res = createRepository<CMappingRoleUser>();
                CMappingRoleUser dbObj = res.read(m => m.Id == Id);

                dbObj.RoleId = ToRoleId;
                dbObj.UserId = ToUserId;

                dbObj.addValidationRule(new MappingRoleUserCannotWithOutRoleOrUserRule(res, dbObj));
                dbObj.addValidationRule(new MappingRoleUserCannotExistsSameMappingRule(res, dbObj));

                dbObj.validate();
                res.update(dbObj);

                commit();

            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }

        public void deleteMappingRoleUser(long RoleId, long UserId)
        {
            try
            {
                IRepository<CMappingRoleUser> res = createRepository<CMappingRoleUser>();
                CMappingRoleUser dbObj = res.read(m => m.RoleId == RoleId && m.UserId == UserId);

                deleteMappingRoleUser(dbObj.Id);
            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }

        public void deleteMappingRoleUser(long Id)
        {
            try
            {
                IRepository<CMappingRoleUser> res = createRepository<CMappingRoleUser>();

                res.delete(typeof(CMappingRoleUser), Id.ToString());

                commit();
            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }
    }
}
