
namespace CMapping.Business.Rule
{
    using System.ComponentModel.DataAnnotations;
    using CAM.Core.Business.Rule;
    using CAM.Core.Model.Validation;
    using CAM.Common.Data;
    using Model.Entity;

    public class MappingRoleUserCannotWithOutRoleOrUserRule : BaseRule<CMappingRoleUser>
    {
        public MappingRoleUserCannotWithOutRoleOrUserRule(IRepository<CMappingRoleUser> res, CMappingRoleUser checkObj)
            : base(res, checkObj)
        {

        }

        public override ValidationResult validate()
        {
            ValidationResult result = ValidationResult.Success;
            if (_checkObj.RoleId == 0 || _checkObj.UserId == 0)
            {
                result = createValidationResult("RoleId", string.Format("RoleId或UserId为0导致无法建立Role到User的映射关系"));
            }
            return result;
        }
    }



    public class MappingRoleUserCannotExistsSameMappingRule : BaseRule<CMappingRoleUser>
    {
        public MappingRoleUserCannotExistsSameMappingRule(IRepository<CMappingRoleUser> res, CMappingRoleUser checkObj)
            : base(res, checkObj)
        {

        }

        public override ValidationResult validate()
        {
            ValidationResult result = ValidationResult.Success;
            int mappingCount = _res.count(m => m.RoleId == _checkObj.RoleId && m.UserId == _checkObj.UserId && m.Id != _checkObj.Id && m.System.DeleteFlag == false);

            if (mappingCount > 0)
            {
                result = createValidationResult("RoleId", string.Format("系统中已存在完全相同的映射关系！"));
            }
            return result;
        }
    }
}
