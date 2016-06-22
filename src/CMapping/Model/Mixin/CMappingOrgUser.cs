
namespace CMapping.Model.Mixin
{
   
    public class CMappingOrgUserMixin
    {
        public long Id { get; set; }
        public long OrganizationId { get; set; }

        public long BranchId { get; set; }

        public long DepartmentId { get; set; }

        public long UserId { get; set; }

        public bool IsManager { get; set; }
    }
}
