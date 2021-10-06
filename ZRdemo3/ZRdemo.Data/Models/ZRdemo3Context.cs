using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZRdemo.Data.Models;

namespace ZRdemo.Data.Models
{
    class ZRdemo3Context : DbContext
    {
        public ZRdemo3Context(DbContextOptions<ZRdemo3Context> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
    }
}
