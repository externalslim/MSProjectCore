using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MS.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Core.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        public static UnitOfWork Current
        {
            get { return _current; }
            set { _current = value; }
        }

        [ThreadStatic]
        private static UnitOfWork _current;

        private MSContext _dbContext;
        private IDbContextTransaction _transaction;

        public MSContext DbContext
        {
            get
            {
                return _dbContext;
            }
            set
            {
                _dbContext = value;
            }
        }

        public UnitOfWork(MSContext context)
        {
            _dbContext = context;
        }

        public void BeginTransaction()
        {
            _transaction = _dbContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            finally
            {
                _transaction.Dispose();
            }
        }

        public void RollBack()
        {
            try
            {
                _transaction.Rollback();
            }
            finally
            {
                _transaction.Dispose();
            }
        }
    }
}
