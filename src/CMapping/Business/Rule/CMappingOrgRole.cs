
namespace CMapping.Business.Rule
{
    using System.ComponentModel.DataAnnotations;
    using CAM.Core.Business.Rule;
    using CAM.Core.Model.Validation;
    using CAM.Common.Data;
    using Model.Entity;

    public class MappingOrgRoleCannotWithOutRoleRule : BaseRule<CMappingOrgRole>
    {
        public MappingOrgRoleCannotWithOutRoleRule(IRepository<CMappingOrgRole> res, CMappingOrgRole checkObj)
            : base(res, checkObj)
        {

        }

        public override ValidationResult validate()
        {
            ValidationResult result = ValidationResult.Success;
            if (_checkObj.RoleId == 0)
            {
                result = createValidationResult("RoleId", string.Format("RoleId为0导致无法建立Organization到Role的映射关系"));
            }
            return result;
        }
    }



    public class MappingOrgRoleCannotExistsSameMappingRule : BaseRule<CMappingOrgRole>
    {
        public MappingOrgRoleCannotExistsSameMappingRule(IRepository<CMappingOrgRole> res, CMappingOrgRole checkObj)
            : base(res, checkObj)
        {

        }

        public override ValidationResult validate()
        {
            ValidationResult result = ValidationResult.Success;
            int mappingCount = _res.count(m => m.OrganizationId == _checkObj.OrganizationId && m.RoleId == _checkObj.RoleId && m.Id != _checkObj.Id && m.System.DeleteFlag == false);

            if (mappingCount > 0)
            {
                result = createValidationResult("RoleId", string.Format("系统中已存在完全相同的映射关系！"));
            }
            return result;
        }
    }

}
