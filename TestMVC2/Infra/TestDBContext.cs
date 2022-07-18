using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestMVC2.Models.Entities;

namespace TestMVC2.Infra
{
    public class TestDBContext : DbContext
    {
        public TestDBContext(string contextKey = "TestDBContext") : base("name=" + contextKey)
        {
            Configuration.UseDatabaseNullSemantics = true;
        }

        public new void Dispose()
        {
            base.Dispose();
        }

        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}