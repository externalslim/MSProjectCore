using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MS.Core.UoW;

namespace MS.Core.RepositoryBase
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext Context { get { return UnitOfWork.Current.DbContext; } }
        protected DbSet<TEntity> DbSet
        {
            get
            {
                return Context.Set<TEntity>();
            }
        }

        #region Crud
        public TEntity Create(TEntity entity)
        {
            try
            {
                return DbSet.Add(entity).Entity;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(TEntity entity)
        {
            try
            {
                DbSet.Attach(entity);
                Context.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(TEntity entity)
        {

            try
            {
                TEntity _entity = entity;
                _entity.GetType().GetProperty("IsDeleted").SetValue(_entity, true);
                this.Update(_entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Read
        public List<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public List<TEntity> GetAllWithFilter(Expression<Func<TEntity, bool>> expression)
        {
            return DbSet.Where(expression).ToList();
        }

        public TEntity GetWithFilter(Expression<Func<TEntity, bool>> expression = null)
        {
            return DbSet.Where(expression).SingleOrDefault();
        }

        #endregion


    }
}
