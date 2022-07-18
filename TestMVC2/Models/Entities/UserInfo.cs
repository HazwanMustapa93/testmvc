using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestMVC2.Models.Entities
{
    [Table("UserInfo")]
    public class UserInfo
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
    }
}