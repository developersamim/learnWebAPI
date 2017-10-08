using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Empower.Models
{
    public class MyUser
    {
        public string id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public bool emailConfirmed { get; set; }
        public string phoneNumber { get; set; }
        public bool twoFactorEnabled { get; set; }
        public List<Role> roleList { get; set; }
    }
}