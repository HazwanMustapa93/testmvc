using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestMVC2.Models.ViewModels
{
    public class SubmitUserViewModel
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public int[] UserRole { get; set; }
    }
}