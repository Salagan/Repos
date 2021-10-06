using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZRdemo.Data.Models
{
    //Class created for aggregation
    public class MemberOfTheTeam
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        
    }
    public enum Gender
    {
        Male,
        Female,
        Other
    }
}
