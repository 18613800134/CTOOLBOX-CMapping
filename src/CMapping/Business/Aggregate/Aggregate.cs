
namespace CMapping.Business.Aggregate
{
    using CAM.Core.Business.Interface;
    using CAM.Core.Business.Aggregate;
    using DBContext;

    public partial class Aggregate : BaseAggregate, IBaseInterfaceCommand<DBContextCMapping>
    {
        public Aggregate()
        {
            this.dbContext = new DBContextCMapping();
        }

        public DBContextCMapping DBContext
        {
            get { return (DBContextCMapping)this.dbContext; }
        }
    }
}
