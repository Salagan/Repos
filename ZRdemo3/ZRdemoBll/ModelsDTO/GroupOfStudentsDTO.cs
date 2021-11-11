using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZRdemoBll.Enums;

namespace ZRdemoBll.ModelsDTO
{
    public class GroupOfStudentsDTO
    {
        public int Id { get; set; }

        public GroupType GroupType { get; set; }

        public string GroupAge { get; set; }
    }
}
