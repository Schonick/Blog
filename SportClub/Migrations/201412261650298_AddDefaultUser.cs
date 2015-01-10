namespace SportClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;

    public partial class AddDefaultUser : DbMigration
    {
        public override void Up()
        {
            //if (!WebSecurity.Initialized)
            //{
            //    WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName",
            //        autoCreateTables:
            //            true);
            //}

            //var roles = (SimpleRoleProvider)Roles.Provider;
            //var membership = (SimpleMembershipProvider)Membership.Provider;

            //if (!roles.RoleExists("Admin"))
            //{
            //    roles.CreateRole("Admin");
            //}
            //if (membership.GetUser("Admin", false) == null)
            //{
            //    membership.CreateUserAndAccount("Admin1", "SuperAdminPassword");
            //}
            //if (!roles.GetRolesForUser("Admin").Contains("Admin"))
            //{
            //    roles.AddUsersToRoles(new[] { "Admin" }, new[] { "Admin" });
            //}

        }

        public override void Down()
        {
            //throw new NotImplementedException();
        }
    }
}