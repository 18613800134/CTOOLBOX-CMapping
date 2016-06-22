
namespace CMapping.Business.Rule
{
    using System.ComponentModel.DataAnnotations;
    using CAM.Core.Business.Rule;
    using CAM.Core.Model.Validation;
    using CAM.Common.Data;
    using Model.Entity;

    public class MappingOrgUserCannotWithOutOrgOrUserRule : BaseRule<CMappingOrgUser>
    {
        public MappingOrgUserCannotWithOutOrgOrUserRule(IRepository<CMappingOrgUser> res, CMappingOrgUser checkObj)
            : base(res, checkObj)
        {

        }

        public override ValidationResult validate()
        {
            ValidationResult result = ValidationResult.Success;
            if (_checkObj.OrganizationId == 0 || _checkObj.UserId == 0)
            {
                result = createValidationResult("OrganizationId", string.Format("OrganizationId或UserId为0导致无法建立Organization到User的映射关系"));
            }
            return result;
        }
    }
}
