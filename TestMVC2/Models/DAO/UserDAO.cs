using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TestMVC2.Infra;
using TestMVC2.Models.DTO;
using TestMVC2.Models.Entities;

namespace TestMVC2.Models.DAO
{
    public class UserDAO
    {
        private readonly TestDBContext _ctx;

        public UserDAO(TestDBContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Role> GetRoles()
        {
            return _ctx.Roles.ToList();
        }

        public UserInfo GetUserById(int userId)
        {
            return _ctx.UserInfos.Find(userId);
        }

        public int UpdateUserInfo()
        {
            return _ctx.SaveChanges();
        }

        public IEnumerable<UserRoleDTO> GetUserRole(int userId)
        {
            var query = from ur in _ctx.UserRoles
                        join r in _ctx.Roles on ur.RoleId equals r.Id
                        where ur.UserId == userId
                        select new UserRoleDTO()
                        {
                            RoleId = ur.RoleId,
                            RoleName = r.RoleName
                        };

            return query.ToList();
        }

        public int DeleteUserRole(int userId)
        {
           return _ctx.Database.ExecuteSqlCommand("DELETE UserRole WHERE UserId = @UserId", new SqlParameter("@UserId", userId));
        }

        public int AddUserRole(IEnumerable<UserRole> userRoles)
        {
            _ctx.UserRoles.AddRange(userRoles);
            return _ctx.SaveChanges();
        }
    }
}