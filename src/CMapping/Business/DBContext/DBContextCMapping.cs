
namespace CMapping.Business.DBContext
{
    using System.Data.Entity;
    using CAM.Common.Data;
    using Model.Entity;

    public class DBContextCMapping : BaseDBContext<DBContextCMapping>
    {
        public IDbSet<CMappingOrgRole> CMappingOrgRole { get; set; }
        public IDbSet<CMappingRoleUser> CMappingRoleUser { get; set; }
        public IDbSet<CMappingOrgUser> CMappingOrgUser { get; set; }

    }

}
