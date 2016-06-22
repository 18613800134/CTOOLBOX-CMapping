using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using CAM.Common.DataProtocol;

using CMapping.Business.Interface;
using CMapping.Business.Aggregate;

using CMapping.Model.Mixin;
using COrganization.Model.Mixin;
using CRole.Model.Mixin;
using CUser.Model.Mixin;

using CAM.Common.Merge;
using CAM.Common.QueryMaker;

namespace UnitTestForCMapping
{
    /// <summary>
    /// TestForReadMixinData 的摘要说明
    /// </summary>
    [TestClass]
    public class TestForReadMixinData
    {
        public TestForReadMixinData()
        {
            //
            //TODO:  在此处添加构造函数逻辑
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，该上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试特性
        //
        // 编写测试时，可以使用以下附加特性: 
        //
        // 在运行类中的第一个测试之前使用 ClassInitialize 运行代码
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // 在类中的所有测试都已运行之后使用 ClassCleanup 运行代码
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // 在运行每个测试之前，使用 TestInitialize 来运行代码
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // 在每个测试运行完之后，使用 TestCleanup 来运行代码
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TryReadMixinData()
        {
            try
            {
                Type ViewMode = null;

                ViewMode = ViewMode.Merge(typeof(CUserMixin))
                                   .Merge(typeof(CMappingOrgUserMixin))
                                   .Merge(typeof(COrganizationMixin))
                                   .Merge(typeof(CBranchMixin))
                                   .Merge(typeof(CDepartmentMixin))
                                   .Merge(typeof(CMappingRoleUserMixin))
                                   .Merge(typeof(CRoleMixin));

                QueryMakerObjectQueue qm = new QueryMakerObjectQueue();
                qm = qm.select(typeof(CUser.Model.Entity.CUserInfo), typeof(CUserMixin), "user")
                       .leftjoin(typeof(CMapping.Model.Entity.CMappingOrgUser), typeof(CMappingOrgUserMixin), "orgmap", "orgmap.UserId=[user].Id")
                       .leftjoin(typeof(COrganization.Model.Entity.COrgOrganization), typeof(COrganizationMixin), "org", "org.Id=orgmap.OrganizationId")
                       .leftjoin(typeof(COrganization.Model.Entity.COrgBranch), typeof(CBranchMixin), "branch", "branch.OrganizationId=org.Id")
                       .leftjoin(typeof(COrganization.Model.Entity.COrgDepartment), typeof(CDepartmentMixin), "department", "department.BranchId=branch.Id")
                       .leftjoin(typeof(CMapping.Model.Entity.CMappingRoleUser), typeof(CMappingRoleUserMixin), "rolemap", "rolemap.UserId=[user].Id")
                       .leftjoin(typeof(CRole.Model.Entity.CRoleRole), typeof(CRoleMixin), "role", "role.Id=rolemap.RoleId")
                       .leftjoin(typeof(CMapping.Model.Entity.CMappingOrgRole), typeof(CMappingOrgRoleMixin), "ormap", "ormap.OrganizationId = org.Id and ormap.RoleId=role.Id")
                       .where("where ormap.OrganizationId = 1");
                       
                //注意：where部分可以直接使用上面的别名（Alias）访问字段

                CMapping.Model.Filter.CMappingOrgUserFilter filter = new CMapping.Model.Filter.CMappingOrgUserFilter();
                filter.OrderName[0] = "CUserMixin_Id";

                ICMappingRoleUserCommand ic = new CMapping.Business.Aggregate.Aggregate();

                object o = qmHelper.readMixinList(ic, ViewMode, qm, typeof(CMapping.Model.Filter.CMappingOrgUserFilter), filter);
                //object o = qmHelper.readMixin(ic, ViewMode, qm);
                string sss = DataPackager.packIt(o, filter.PageInfo);
                Console.WriteLine(sss);
                Console.WriteLine(DataPackager.packIt(o, filter.PageInfo));
            }
            catch (Exception ex)
            {
                Console.WriteLine(DataPackager.packError(ex));
            }
        }
    }
}
