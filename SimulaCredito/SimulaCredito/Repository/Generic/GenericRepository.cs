﻿using Microsoft.EntityFrameworkCore;
using SimulaCredito.Models;
using SimulaCredito.Models.Base;
using SimulaCredito.Models.Context;

namespace SimulaCredito.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected SqlContext _context;
        private DbSet<T> dataset;

        public GenericRepository(SqlContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }

        public List<T> FindAll()
        {
            return dataset.ToList();
        }

        public T FindById(long id)
        {
            return dataset.SingleOrDefault(t => t.Id.Equals(id));
        }

        public T Create(T item)
        {
            try
            {
                dataset.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public T Update(T item)
        {
            var result = dataset.SingleOrDefault(t => t.Id.Equals(item.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                    return result;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
                return null;
        }

        public void DeleteById(long id)
        {
            var result = dataset.SingleOrDefault(t => t.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    dataset.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public bool Exists(long id)
        {
            return dataset.Any(t => t.Id.Equals(id));
        }
    }
}
