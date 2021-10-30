﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZRdemoData.Intrefaces;
using ZRdemoData.Models;

namespace ZRdemoData.Repositories
{
    public class GroupOfStudentsRepository : GenericRepository<GroupOfStudents>, IGroupOfStudentsRepository
    {
        public GroupOfStudentsRepository(ZRdemoContext context)
            : base(context)
        {
        }

        public new IEnumerable<GroupOfStudents> GetAll()
        {
            return this._context.GroupOfStudents.Include(s => s.Students)
                .Include(t => t.TrainingDays)
                .ToList();
        }

        public new IEnumerable<GroupOfStudents> GetById(int id)
        {
            return this._context.GroupOfStudents.Where(g => g.Id == id)
                .Include(s => s.Students)
                .Include(t => t.TrainingDays)
                    .ThenInclude(g => g.Trainings)
                .ToList();
        }
    }
}
