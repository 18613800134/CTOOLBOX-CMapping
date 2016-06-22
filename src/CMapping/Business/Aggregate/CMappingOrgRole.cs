
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

    public partial class Aggregate : ICMappingOrgRoleCommand
    {

        public void addMappingOrgRole(long OrganizationId, long RoleId)
        {
            try
            {
                IRepository<CMappingOrgRole> res = createRepository<CMappingOrgRole>();
                CMappingOrgRole dbObj = CMappingOrgRoleFactory.createMapping();

                dbObj.OrganizationId = OrganizationId;
                dbObj.RoleId = RoleId;

                dbObj.addValidationRule(new MappingOrgRoleCannotWithOutRoleRule(res, dbObj));
                dbObj.addValidationRule(new MappingOrgRoleCannotExistsSameMappingRule(res, dbObj));

                dbObj.validate();
                res.add(dbObj);

                commit();

            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }

        public void updateMappingOrgRole(long OrganizationId, long RoleId, long ToOrganizationId, long ToRoleId)
        {
            try
            {
                IRepository<CMappingOrgRole> res = createRepository<CMappingOrgRole>();
                CMappingOrgRole dbObj = res.read(m => m.OrganizationId == OrganizationId && m.RoleId == RoleId);

                dbObj.OrganizationId = ToOrganizationId;
                dbObj.RoleId = ToRoleId;

                dbObj.addValidationRule(new MappingOrgRoleCannotWithOutRoleRule(res, dbObj));
                dbObj.addValidationRule(new MappingOrgRoleCannotExistsSameMappingRule(res, dbObj));

                dbObj.validate();
                res.update(dbObj);

                commit();

            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }

        public void updateMappingOrgRole(long Id, long ToOrganizationId, long ToRoleId)
        {
            try
            {
                IRepository<CMappingOrgRole> res = createRepository<CMappingOrgRole>();
                CMappingOrgRole dbObj = res.read(m => m.Id == Id);

                dbObj.OrganizationId = ToOrganizationId;
                dbObj.RoleId = ToRoleId;

                dbObj.addValidationRule(new MappingOrgRoleCannotWithOutRoleRule(res, dbObj));
                dbObj.addValidationRule(new MappingOrgRoleCannotExistsSameMappingRule(res, dbObj));

                dbObj.validate();
                res.update(dbObj);

                commit();

            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }

        public void deleteMappingOrgRole(long OrganizationId, long RoleId)
        {
            try
            {
                IRepository<CMappingOrgRole> res = createRepository<CMappingOrgRole>();
                CMappingOrgRole dbObj = res.read(m => m.OrganizationId == OrganizationId && m.RoleId == RoleId);

                deleteMappingOrgRole(dbObj.Id);
            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }

        public void deleteMappingOrgRole(long Id)
        {
            try
            {
                IRepository<CMappingOrgRole> res = createRepository<CMappingOrgRole>();

                res.delete(typeof(CMappingOrgRole), Id.ToString());

                commit();
            }
            catch (Exception ex)
            {
                ErrorHandler.ThrowException(ex);
            }
        }
    }
}
