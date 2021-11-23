﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZRdemoData.Intrefaces;
using ZRdemoData.Models;

namespace ZRdemoData.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {
        protected readonly ZRdemoContext _context;

        public GenericRepository(ZRdemoContext context)
        {
            this._context = context;
        }

        public virtual void Add(T entity)
        {
            this._context.Set<T>().Add(entity);
        }

        public virtual void AddRange(IEnumerable<T> entities)
        {
            this._context.Set<T>().AddRange(entities);
        }

        public async virtual Task<IEnumerable<T>> FindListAsync(Expression<Func<T, bool>> expression)
        {
            return await this._context.Set<T>().Where(expression).ToListAsync();
        }

        public async virtual Task<T> FindOneAsync(Expression<Func<T, bool>> expression)
        {
            return await this._context.Set<T>().Where(expression).FirstOrDefaultAsync();
        }

        public async virtual Task<IEnumerable<T>> GetAll()
        {
            return await this._context.Set<T>().ToListAsync();
        }

        public async virtual Task<T> GetById(int id)
        {
            return await this._context.Set<T>().FindAsync(id);
        }

        public virtual void Update(T entity)
        {
            // this._context.Set<T>().Attach(entity);
            this._context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public virtual void Remove(T entity)
        {
            this._context.Set<T>().Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<T> entities)
        {
            this._context.Set<T>().RemoveRange(entities);
        }
    }
}
