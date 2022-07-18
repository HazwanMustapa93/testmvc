using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMVC2.Infra;
using TestMVC2.Models;
using TestMVC2.Models.ViewModels;
using TestMVC2.Services;

namespace TestMVC2.Controllers
{
    public class ManagementController : Controller
    {
        private readonly TestDBContext _ctx;
        private readonly UserService _userService;

        private int _currentUserId = 1; // hardcoded
         
        public ManagementController()
        {
            _ctx = new TestDBContext();
            _userService = new UserService(_ctx);
        }

        [HttpGet]
        public ActionResult Index()
        {
            var roles = _userService.GetRoles();

            var viewModel = _userService.GetUserById(_currentUserId);

            ViewBag.roleList = roles;

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult SubmitUser(SubmitUserViewModel requestModel)
        {
            var results = _userService.UpdateUser(_currentUserId, requestModel);

            return RedirectToAction("Index");
        }

    }
}