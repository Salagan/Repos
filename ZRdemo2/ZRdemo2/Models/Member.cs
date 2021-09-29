using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZRdemo2.Models
{
    public abstract class Member
    {
        public  string FirstName { get; set; }
        public  string LastName { get; set; }
        public  int Age { get; set; }
        public  string PhoneNumber { get; set; }
    }
}