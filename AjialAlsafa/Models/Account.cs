using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AjialAlsafa.Models
{
    public class Account
    {

        public int id { get; set; }
       
        public string name { get; set; }

        public string password { get; set; }
        public string phoneNo { get; set; }
        public string phoneNo2 { get; set; } = "";
        public string email { get; set; } = "";
        public string address { get; set; }
        public string userName { get; set; }
        public int accountTypeId { get; set; }
        public int schoolId { get; set; } = 1;
        [Computed]
        public string createdAt { get; set; }
        public int createdBy { get; set; } = 0;
    }
}