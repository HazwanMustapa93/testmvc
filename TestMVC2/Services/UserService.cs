using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestMVC2.Infra;
using TestMVC2.Models.DAO;
using TestMVC2.Models.Entities;
using TestMVC2.Models.ViewModels;

namespace TestMVC2.Services
{
    public class UserService
    {
        private readonly TestDBContext _ctx;
        private readonly UserDAO _userDAO;
        public UserService(TestDBContext ctx)
        {
            _ctx = ctx;
            _userDAO = new UserDAO(ctx);
        }

        public IEnumerable<Role> GetRoles()
        {
           return _userDAO.GetRoles();
        }

        public SubmitUserViewModel GetUserById(int userId)
        {
            var targetUserRoles = _userDAO.GetUserRole(userId);
            var targetUserInfo = _userDAO.GetUserById(userId);

            return new SubmitUserViewModel()
            {
                FullName = targetUserInfo.FullName,
                UserName = targetUserInfo.Username,
                UserRole = targetUserRoles.Select(a => a.RoleId).ToArray()
            };
        }

        public SubmitUserViewModel UpdateUser(int userId, SubmitUserViewModel requestModel)
        {
            var targetUserInfo = _userDAO.GetUserById(userId);

            targetUserInfo.Username = requestModel.UserName;
            targetUserInfo.FullName = requestModel.FullName;

            _userDAO.UpdateUserInfo();

            var newUserRoles = new List<UserRole>();
            foreach (var roleId in requestModel.UserRole)
            {
                newUserRoles.Add(new UserRole()
                {
                    RoleId = roleId,
                    UserId = userId
                });
            }

            _userDAO.DeleteUserRole(userId);
            _userDAO.AddUserRole(newUserRoles);

            return GetUserById(userId);
        }
    }
}