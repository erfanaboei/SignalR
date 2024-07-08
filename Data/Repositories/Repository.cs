using System;
using System.Collections.Generic;
using System.Linq;
using Data.Context;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        private readonly ProjectContext _context;
        private DbSet<TEntity> Entities { get; }
        public virtual IQueryable<TEntity> Table => Entities;
        public virtual IQueryable<TEntity>  TableNoTracking => Entities.AsNoTracking();

        protected Repository(ProjectContext dbContext)
        {
            _context = dbContext;
            Entities = _context.Set<TEntity>(); // City => Cities
        }
        
        public virtual List<TEntity> GetAll()
        {
            return Entities.ToList();
        }

        public virtual TEntity GetById(int id)
        {
            return Entities.Find(id);
        }

        public virtual TEntity Add(TEntity model)
        {
            try
            {
                Entities.Add(model);
                Save();
                return model;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public virtual TEntity Update(TEntity model)
        {
            try
            {
                Entities.Update(model);
                Save();
                return model;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public bool Delete(TEntity model)
        {
            try
            {
                Entities.Remove(model);
                Save();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public virtual void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}